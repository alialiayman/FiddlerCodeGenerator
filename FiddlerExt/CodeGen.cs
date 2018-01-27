using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Fiddler;

namespace onSoft
{
    public class CodeGen
    {
        private readonly Dictionary<string, string> _headerOverrides = new Dictionary<string, string>();

        public CodeGen()
        {
            _headerOverrides.Add("User-Agent",
                "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36");
            _headerOverrides.Add("Connection", string.Empty);
            _headerOverrides.Add("Accept-Encoding", string.Empty);
            _headerOverrides.Add("Content-Length", string.Empty);
            _headerOverrides.Add("Cookie",string.Empty);
        }

        public string InputClass { get; set; }
        public string OutputClass { get; set; }
        public string Url { get; set; }

        public List<string> GenerateCode(Session[] oSessions)
        {
            var output = new List<string>();
            output.Add(GenerateDeclarations(oSessions));
            foreach (var oSession in oSessions)
            {
                output.Add(GenerateCode(oSession));
            }

            output.Add(GenerateFooter(oSessions));
            return output;

        }

        private string GenerateDeclarations(Session[] oSessions)
        {
            var sr = new StringBuilder();
            sr.AppendLine("private readonly CookieContainer CookieJar = new CookieContainer();");
            sr.AppendLine("Dictionary<string,string> DomControls = new Dictionary<string,string>();");
            
            sr.AppendLine("public void RunAll() {");
            foreach (var oSession in oSessions)
            {
                sr.AppendLine($"{CreateMethodName(oSession)}();");
            }


            sr.AppendLine("}");

            return sr.ToString();
        }


        private string GenerateFooter(Session[] oSessions)
        {
            var sr = new StringBuilder();
  
            sr.AppendLine("private Dictionary<string, string> GetDomControlElements(string html, List<string> inputElements)");
            sr.AppendLine("{");
            sr.AppendLine("var output = new Dictionary<string, string>();");
            sr.AppendLine("var doc = new HtmlAgilityPack.HtmlDocument();");
            sr.AppendLine("doc.LoadHtml(html);");

            sr.AppendLine("GetDomControlElement(doc, output, \"__VIEWSTATE\");");
            sr.AppendLine("GetDomControlElement(doc, output, \"__VIEWSTATEGENERATOR\");");
            sr.AppendLine("GetDomControlElement(doc, output, \"__EVENTVALIDATION\");");
            sr.AppendLine("foreach (var inputElement in inputElements)");
            sr.AppendLine("{");
            sr.AppendLine("GetDomControlElement(doc, output, inputElement);");
            sr.AppendLine("}");
            sr.AppendLine("return output;");
            sr.AppendLine("}");

            sr.AppendLine("private void GetDomControlElement(HtmlAgilityPack.HtmlDocument doc, Dictionary<string, string> controlsDictionary, string controlItem)");
            sr.AppendLine("{");
            sr.AppendLine("var vsNode = doc.GetElementbyId(\"__VIEWSTATE\");");
            sr.AppendLine("if (vsNode != null && vsNode.HasAttributes && vsNode.Attributes[\"value\"] != null)");
            sr.AppendLine("{");
            sr.AppendLine("if (controlsDictionary.Keys.Contains(controlItem))");
            sr.AppendLine("controlsDictionary[controlItem] = EscapeUriString(vsNode.Attributes[\"value\"].Value);");
            sr.AppendLine("else");
            sr.AppendLine("controlsDictionary.Add(controlItem, EscapeUriString(vsNode.Attributes[\"value\"].Value));");
            sr.AppendLine("}");
            sr.AppendLine("else //Try to parse the html for ");
            sr.AppendLine("{");
            sr.AppendLine("var regViewState = Regex.Match(doc.ToString(), @\"__VIEWSTATE\" + Regex.Escape(\"|\") + \"(.+?)\" + Regex.Escape(\"| \"));");
            sr.AppendLine("if (regViewState.Success)");
            sr.AppendLine("{");
            sr.AppendLine("if (controlsDictionary.Keys.Contains(controlItem))");
            sr.AppendLine("controlsDictionary[controlItem] = EscapeUriString(regViewState.Groups[1].ToString());");
            sr.AppendLine("else");
            sr.AppendLine("controlsDictionary.Add(controlItem, EscapeUriString(regViewState.Groups[1].ToString()));");
            sr.AppendLine("}");
            sr.AppendLine("}");
            sr.AppendLine("}");



            sr.AppendLine("private string EscapeUriString(string input)");
            sr.AppendLine("{");
            sr.AppendLine("var limit = 2000;");

            sr.AppendLine("var sb = new StringBuilder();");
            sr.AppendLine("var loops = input.Length / limit;");

            sr.AppendLine("for (var i = 0; i <= loops; i++)");
            sr.AppendLine("{");
            sr.AppendLine("sb.Append(i < loops");
            sr.AppendLine("? Uri.EscapeDataString(input.Substring(limit * i, limit))");
            sr.AppendLine(": Uri.EscapeDataString(input.Substring(limit * i)));");
            sr.AppendLine("}");

            sr.AppendLine("return sb.ToString(); ");
            sr.AppendLine("}");


            return sr.ToString();
        }


        public string GenerateCode(Session oSession)
        {
            switch (oSession.RequestMethod)
            {
                case "GET":
                    return GenerateGetRequest(oSession);
                case "POST":
                    return GeneratePostRequest(oSession);
                default:
                    return "Unknown Request Method";
            }
        }

        private string GenerateGetRequest(Session oSession)
        {
            var code = new StringBuilder();
            var methodName = CreateMethodName(oSession);
            AppendLine(code, 3, $"\tprivate IRestResponse<{OutputClass}> {methodName}()");
            AppendLine(code, 3, "{");

            //if (Url.Contains("{"))
            {
                var firstUrl = Url; //.Substring(0, Url.IndexOf("{"));
                var secondtUrl = string.Empty; // Url.Substring(Url.IndexOf("{"));
                AppendLine(code, 4, $"var client =  new RestClient(\"{oSession.fullUrl}\");");


                AppendLine(code, 4, "var request = new RestRequest(\"" + secondtUrl + "\", Method." +
                                    oSession.RequestMethod + ");");
                AppendLine(code,4, "client.CookieContainer = CookieJar;");
                var matches = Regex.Matches(oSession.fullUrl, "({.*?})");
                if (matches.Count > 0)
                    foreach (Match mtch in matches)
                        AppendLine(code, 4, "request.AddParameter(\"" +
                                            mtch.Groups[1].ToString()
                                                .Substring(1, mtch.Groups[1].ToString().Length - 2) +
                                            "\", \"parametervalue\");)");
            }
            foreach (var header in oSession.RequestHeaders)
                AddHeader(code, header);


            AppendLine(code, 4, "//client.ExecuteAsync<LoginResponse>(request, response =>");
            AppendLine(code, 4, "// {");
            AppendLine(code, 4, "//  some action here based on response.Data;");
            AppendLine(code, 4, "// });");

            AppendLine(code, 4, "var response = client.Execute<" + OutputClass + ">(request);");
            AppendLine(code, 4, "loginResponse = response.Data;");
            AppendLine(code, 4, "DomControls = GetDomControlElements(response.Content, new List<string>());");
            AppendLine(code, 4, "return response;");
            AppendLine(code, 3, "}");


            return code.ToString();
        }

        private string CreateMethodName(Session oSession)
        {
            //If url contains .aspx then take the name of the file plus Id otherwise use id

            if (oSession.fullUrl.ToLower().Contains(".aspx"))
            {
                var match = Regex.Match(oSession.fullUrl.ToLower(), @"(/(\w+?))\.aspx");
                if (match.Success)
                    return $"{oSession.RequestMethod}{match.Groups[2].ToString()}{oSession.id}";


            }
            return $"Run{oSession.RequestMethod}{oSession.id}";

        }


        private string GeneratePostRequest(Session oSession)
        {
            var code = new StringBuilder();
            var methodName = CreateMethodName(oSession);
            code.AppendLine($"\tprivate IRestResponse<{OutputClass}> {methodName}({InputClass} input)");
            code.AppendLine("\t{");
            code.AppendLine($"\tvar client = new RestClient(\"{oSession.fullUrl}\");");
            code.AppendLine("\tvar request = new RestRequest(\"\",Method.POST);");

            //code.AppendLine("\trequest.AddUrlSegment("businessChannelId", businessChanel);");
            //code.AppendLine("\trequest.AddUrlSegment("originatorId", originator);");

            AppendLine(code, 4, "client.CookieContainer = CookieJar;");
            foreach (var header in oSession.RequestHeaders)
                AddHeader(code, header);
            //AddBody here
            code.AppendLine($"\tvar srBody = new StringBuilder();");
            var bodySplit = oSession.GetRequestBodyAsString().Split('&');
            foreach (var s in bodySplit)
            {
                var keyValue = s.Split('=');
                var paramKey = keyValue[0];
                var paramValue = string.Empty;
                if (keyValue.Count() > 1)
                    paramValue = keyValue[1];

                code.AppendLine($"\tsrBody.Append(\"{paramKey}=\" + \"{paramValue}\" + \"&\");");
            }
            code.AppendLine($"\tvar body = srBody.ToString();");
            code.AppendLine($"\trequest.AddParameter(\"text/xml\", body, ParameterType.RequestBody);");
            code.AppendLine("\tvar requestObject = input;");
            code.AppendLine("\trequest.AddJsonBody(requestObject);");
            code.AppendLine("\tvar response = client.Execute<" + OutputClass + ">(request);");
            code.AppendLine("\tsaveResponse = response.Data;");
            AppendLine(code, 4, "DomControls = GetDomControlElements(response.Content, new List<string>());");
            code.AppendLine("\treturn response;");
            code.AppendLine("\t}");

            return code.ToString();
        }

        private void AppendLine(StringBuilder sr, int numberOfTabs, string inputString)
        {
            sr.AppendLine(new string('\t', numberOfTabs) + inputString);
        }

        private void AddHeader(StringBuilder code, HTTPHeaderItem header)
        {
            if (_headerOverrides.ContainsKey(header.Name) && _headerOverrides[header.Name] != string.Empty)
            {
                AppendLine(code, 4, "request.AddHeader(\"" + header.Name + "\", \"" +
                                    _headerOverrides[header.Name] +
                                    "\");");
            }
            else if (_headerOverrides.ContainsKey(header.Name) && _headerOverrides[header.Name] == string.Empty)
            {
            }
            else
            {
                AppendLine(code, 4, "request.AddHeader(\"" + header.Name + "\", \"" + header.Value + "\");");
            }
        }
    }
}