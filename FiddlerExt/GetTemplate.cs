using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace onSoft
{
    public class GetTemplate: onHttpBase
    {
        
        public Communication Execute(Communication input)
        {
            
            var client = new RestClient(input.Url);
            var request = new RestRequest("", Method.GET);
            client.CookieContainer = input.CookieJar;

            //{Headers}

            var response = client.Execute(request);
            UpdateCommunication(client, response);
            return baseCommunication;
        }


    }
}
