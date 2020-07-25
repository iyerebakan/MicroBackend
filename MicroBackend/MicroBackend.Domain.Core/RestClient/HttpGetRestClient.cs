using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace MicroBackend.Domain.Core.RestClient
{
    public class HttpGetRestClient : RestSharp.RestRequest
    {
        public HttpGetRestClient() : base(Method.GET)
        {
            this.AddHeader("Content-Type", "application/json");
        }
       
    }
}
 