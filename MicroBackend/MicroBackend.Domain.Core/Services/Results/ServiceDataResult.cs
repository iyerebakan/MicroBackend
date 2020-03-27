using MicroBackend.Domain.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Services.Results
{
    public class ServiceDataResult<T> : ServiceResult, IServiceDataResult<T>
    {
        public ServiceDataResult(T data,int code, bool success, string message) : base(code,success, message)
        {
            Data = data;
        }

        public ServiceDataResult(T data, int code,bool success) : base(code,success)
        {
            Data = data;
        }

        public T Data { get; }

    }
}
