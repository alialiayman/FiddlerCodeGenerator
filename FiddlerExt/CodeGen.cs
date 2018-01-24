using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Fiddler;

namespace onSoft
{
    public class CodeGen
    {
        private readonly Dictionary<string, string> _headersOverride = new Dictionary<string, string>();

        public CodeGen()
        {
            _headersOverride.Add("User-Agent",
                "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36");
            _headersOverride.Add("Connection", string.Empty);
            _headersOverride.Add("Accept-Encoding", string.Empty);
            _headersOverride.Add("Content-Length", string.Empty);
        }

        public string InputClass { get; set; }
        public string OutputClass { get; set; }
        public string Url { get; set; }


        public string MakeRestSharpCode(Session oSession)
        {
            if (oSession.RequestMethod == "GET")
                return MakeGetRequest(oSession);
            return MakePostRequest(oSession);
        }

        private string MakeGetRequest(Session oSession)
        {
            var code = new StringBuilder();
            AppendLine(code, 3, $"public IRestResponse<{OutputClass}> Get{oSession.id}()");
            AppendLine(code, 3, "{");

            if (Url.Contains("{"))
            {
                var firstUrl = Url.Substring(0, Url.IndexOf("{"));
                var secondtUrl = Url.Substring(Url.IndexOf("{"));
                AppendLine(code, 4, "var client =  new RestClient(\"" + firstUrl + "\");");


                AppendLine(code, 4, "var request = new RestRequest(\"" + secondtUrl + "\", Method." +
                                    oSession.RequestMethod + ");");

                var matches = Regex.Matches(Url, "({.*?})");
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
            AppendLine(code, 4, "return response;");
            AppendLine(code, 3, "}");


            return code.ToString();
        }

        private void AppendLine(StringBuilder sr, int numberOfTabs, string inputString)
        {
            sr.AppendLine(new string('\t', numberOfTabs) + inputString);
        }

        private void AddHeader(StringBuilder code, HTTPHeaderItem header)
        {
            if (_headersOverride.ContainsKey(header.Name) && _headersOverride[header.Name] != string.Empty)
            {
                AppendLine(code, 4, "request.AddHeader(\"" + header.Name + "\", \"" +
                                    _headersOverride[header.Name] +
                                    "\")");
            }
            else if (_headersOverride.ContainsKey(header.Name) && _headersOverride[header.Name] == string.Empty)
            {
            }
            else
            {
                AppendLine(code, 4, "request.AddHeader(\"" + header.Name + "\", \"" + header.Value + "\")");
            }
        }

        private string MakePostRequest(Session oSession)
        {
            var code = new StringBuilder();
            code.AppendLine($"\tpublic IRestResponse<{OutputClass}> Post{oSession.id}({InputClass} input)");
            code.AppendLine("\t{");
            code.AppendLine("\tvar client = new RestClient(\"" + oSession.fullUrl + "\");");
            code.AppendLine("\tvar request = new RestRequest(\"\",Method.POST);");

            //code.AppendLine("\trequest.AddUrlSegment("businessChannelId", businessChanel);");
            //code.AppendLine("\trequest.AddUrlSegment("originatorId", originator);");


            foreach (var header in oSession.RequestHeaders)
                AddHeader(code, header);

            code.AppendLine("\tvar requestObject = input;");
            code.AppendLine("\trequest.AddJsonBody(requestObject);");
            code.AppendLine("\tvar response = client.Execute<" + OutputClass + ">(request);");
            code.AppendLine("\tsaveResponse = response.Data;");
            code.AppendLine("\treturn response;");
            code.AppendLine("\t}");

            return code.ToString();
        }
    }
}