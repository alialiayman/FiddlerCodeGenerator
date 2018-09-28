using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace onSoft
{
    public class PostTemplate: onHttpBase
    {
        //{Body}
        //Use https://app.quicktype.io/ to convert the body above into C# class then strongly type the postObject below
        public Communication Execute(Communication input, object postObject)
        {
            var client = new RestClient(input.Url);
            var request = new RestRequest("", Method.POST);
            client.CookieContainer = input.CookieJar;

            //{Headers}

            request.AddJsonBody(postObject);
            var response = client.Execute(request);
            UpdateCommunication(client, response);
            return baseCommunication;
        }
    }
}
