using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroBackend.Domain.Core.RestClient
{
    public interface IRestClient<TRequest, TResponse>
        where TRequest : class, new()
    {
        TResponse Post(TRequest request);
        TResponse Post();
        Task<TResponse> PostAsync(TRequest request);
        Task<TResponse> PostAsync();

        TResponse Get();
        Task<TResponse> GetAsync();
    }
}
