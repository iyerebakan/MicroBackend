using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.RestClient
{
    public class HttpPostRestClient : RestSharp.RestRequest
    {
        public HttpPostRestClient(object request) : base(Method.POST)
        {
            this.AddHeader("Content-Type", "application/json");
            this.AddParameter("application/json", Newtonsoft.Json.JsonConvert.SerializeObject(request), ParameterType.RequestBody);
        }
        public HttpPostRestClient() : base(Method.POST)
        {

        }

    }
}
