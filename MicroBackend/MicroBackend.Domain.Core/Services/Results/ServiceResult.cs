using MicroBackend.Domain.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Services.Results
{
    public class ServiceResult : IServiceResult
    {
        public ServiceResult(int code,bool success, string message)
        {
            Message = message;
            Code = code;
            Success = success;
        }

        public ServiceResult(int code,bool success)
        {
            Success = success;
            Code = code;
        }

        public int Code { get; }
        public string Message { get; }
        public bool Success { get; }
    }
}
