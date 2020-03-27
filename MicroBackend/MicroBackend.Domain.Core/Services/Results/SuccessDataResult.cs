using MicroBackend.Domain.Core.Services.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Services.Results
{
    public class SuccessDataResult<T> : ServiceDataResult<T>
    {
        public SuccessDataResult(T data) : base(data,GlobalSuccess.Competed, true)
        {
        }

        public SuccessDataResult(T data, string message) : base(data, GlobalSuccess.Competed, true, message)
        {
        }

        public SuccessDataResult(string message) : base(default, GlobalSuccess.Competed, true, message)
        {
        }

        public SuccessDataResult() : base(default, GlobalSuccess.Competed, true)
        {

        }
    }
}
