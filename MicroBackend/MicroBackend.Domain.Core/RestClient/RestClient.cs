using Microsoft.AspNetCore.Server.HttpSys;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroBackend.Domain.Core.RestClient
{
    public class RestClient<TRequest, TResponse> : IRestClient<TRequest, TResponse>
        where TRequest : class, new()
    {
        private readonly string _url;
        private readonly RestSharp.RestClient client;
        public RestClient(string url)
        {
            _url = url;
            client = new RestSharp.RestClient(_url);
        }

        public TResponse Get()
        {
            IRestResponse response = client.Execute(new HttpGetRestClient());
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(response.Content);
        }

        public async Task<TResponse> GetAsync()
        {
            var response = await client.ExecuteAsync<TResponse>((new HttpGetRestClient()));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(response.Content);
        }

        public TResponse Post(TRequest request)
        {
            IRestResponse response = client.Execute(new HttpPostRestClient(request));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(response.Content);
        }

        public TResponse Post()
        {
            IRestResponse response = client.Execute(new HttpPostRestClient());
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(response.Content);
        }

        public async Task<TResponse> PostAsync(TRequest request)
        {
            var response = await client.ExecuteAsync<TResponse>((new HttpPostRestClient(request)));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(response.Content);
        }

        public async Task<TResponse> PostAsync()
        {
            var response = await client.ExecuteAsync<TResponse>((new HttpPostRestClient()));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(response.Content);
        }
    }
}
