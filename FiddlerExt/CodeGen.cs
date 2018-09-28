using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            foreach (var oSession in oSessions)
            {
                output.Add(GenerateCode(oSession));
            }
            return output;
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
            var getTemplate = new StringBuilder();

                getTemplate = getTemplate.Append(File.ReadAllText(@"Scripts\GetTemplate.cs"));
            

            var headers = new StringBuilder();
            foreach (var header in oSession.RequestHeaders)
                AddHeader(headers, header);


            getTemplate.Replace("//{Headers}", headers.ToString());
            getTemplate.Replace("class GetTemplate", "class " + oSession.RequestMethod + oSession.id);
            return getTemplate.ToString();
        }

        private string GeneratePostRequest(Session oSession)
        {
            var postTemplate = new StringBuilder();
                postTemplate = postTemplate.Append(File.ReadAllText(@"Scripts\PostTemplate.cs"));
            

            var headers = new StringBuilder();
            foreach (var header in oSession.RequestHeaders)
                AddHeader(headers, header);


            postTemplate.Replace("//{Headers}", headers.ToString());
            postTemplate.Replace("//{Body}", "//" + oSession.GetRequestBodyAsString()); //Assuming body is json
            postTemplate.Replace("class PostTemplate", "class " + oSession.RequestMethod + oSession.id);
            return postTemplate.ToString();
        }


        private void AddHeader(StringBuilder code, HTTPHeaderItem header)
        {
            if (header.Name == "Cookie")
                code.AppendLine($"//request.AddHeader(\"{header.Name}\",\"{header.Value}\");");
            else if (_headerOverrides.ContainsKey(header.Name))
                code.AppendLine($"request.AddHeader(\"{header.Name}\",\"{_headerOverrides[header.Name]}\");");
            else
            code.AppendLine($"request.AddHeader(\"{header.Name}\",\"{header.Value}\");");
        }
    }
}