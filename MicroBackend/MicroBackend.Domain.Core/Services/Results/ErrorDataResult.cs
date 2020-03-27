using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Services.Results
{
    public class ErrorDataResult<T> : ServiceDataResult<T>
    {
        public ErrorDataResult(T data,int code) : base(data,code, false)
        {
        }

        public ErrorDataResult(T data,int code, string message) : base(data,code, false, message)
        {
        }

        public ErrorDataResult(int code,string message) : base(default, code,false, message)
        {
        }
    }
}
