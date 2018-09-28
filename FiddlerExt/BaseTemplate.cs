using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace onSoft
{
    public  class onHttpBase
    {
        
        protected Communication baseCommunication;
        protected List<string> AdditionalDomControlElements = new List<string>();
        public onHttpBase()
        {

        }

        public onHttpBase(List<string> additionalDomControlElements )
        {
            AdditionalDomControlElements = additionalDomControlElements;
        }
        protected Communication UpdateCommunication(RestClient client, IRestResponse response)
        {
            baseCommunication = new Communication();
            baseCommunication.Html = response.Content;
            baseCommunication.CookieJar = client.CookieContainer;
            baseCommunication.AdditionalDomElements = GetDomControlElements(response.Content);
            return baseCommunication;
        }

        protected  Dictionary<string, string> GetDomControlElements(string html)
        {
            var output = new Dictionary<string, string>();
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            baseCommunication.ViewState = ReadStandardControlElements(doc, "__VIEWSTATE");
            baseCommunication.ViewStateGenerator = ReadStandardControlElements(doc, "__VIEWSTATEGENERATOR");
            baseCommunication.EventValidation = ReadStandardControlElements(doc, "__EVENTVALIDATION");
            baseCommunication.RequestVerificationToken = ReadStandardControlElements(doc, "__RequestVerificationToken");
            foreach (var inputElement in AdditionalDomControlElements)
            {
                GetDomControlElement(doc, output, inputElement);
            }
            return output;
        }

        private string ReadStandardControlElements(HtmlAgilityPack.HtmlDocument doc, string controlElement)
        {
            var vsNode = doc.GetElementbyId(controlElement);
            if (vsNode != null && vsNode.HasAttributes && vsNode.Attributes["value"] != null)
            {
                return EscapeUriString(vsNode.Attributes["value"].Value);
            }
            else //Try to parse the html for 
            {
                var regViewState = Regex.Match(doc.ToString(), controlElement + Regex.Escape("|") + "(.+?)" + Regex.Escape("| "));
                if (regViewState.Success)
                {
                    return EscapeUriString(regViewState.Groups[1].ToString());
                }
            }
            return string.Empty;
        }

        protected void GetDomControlElement(HtmlAgilityPack.HtmlDocument doc, Dictionary<string, string> controlsDictionary, string controlItem)
        {
            var element = doc.GetElementbyId(controlItem);
            if (element != null && element.HasAttributes && element.Attributes["value"] != null)
            {
                if (controlsDictionary.Keys.Contains(controlItem))
                    controlsDictionary[controlItem] = EscapeUriString(element.Attributes["value"].Value);
                else
                    controlsDictionary.Add(controlItem, EscapeUriString(element.Attributes["value"].Value));
            }
            else //Try to parse the html for 
            {
                var elementString = Regex.Match(doc.ToString(), controlItem + Regex.Escape("|") + "(.+?)" + Regex.Escape("| "));
                if (elementString.Success)
                {
                    if (controlsDictionary.Keys.Contains(controlItem))
                        controlsDictionary[controlItem] = EscapeUriString(elementString.Groups[1].ToString());
                    else
                        controlsDictionary.Add(controlItem, EscapeUriString(elementString.Groups[1].ToString()));
                }
            }
        }

        protected string EscapeUriString(string input)
        {
            var limit = 2000;
            var sb = new StringBuilder();
            var loops = input.Length / limit;
            for (var i = 0; i <= loops; i++)
            {
                sb.Append(i < loops
                ? Uri.EscapeDataString(input.Substring(limit * i, limit))
                : Uri.EscapeDataString(input.Substring(limit * i)));
            }
            return sb.ToString();
        }
    }

    public class Communication
    {
        public string Html { get; set; }
        public IRestResponse RestResponse { get; set; }
        public string ViewState { get; set; }
        public bool IsSuccess { get; set; }
        public string EventValidation { get; set; }
        public string ViewStateGenerator { get; set; }
        public string RequestVerificationToken { get; set; }
        public CookieContainer CookieJar { get; set; }
        public string Url { get; set; }
        public Dictionary<string, string> AdditionalDomElements = new Dictionary<string, string>();

    }
}
