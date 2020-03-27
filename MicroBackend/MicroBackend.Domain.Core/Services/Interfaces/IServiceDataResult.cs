using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Services.Interfaces
{
    public interface IServiceDataResult<out T> : IServiceResult
    {
        T Data { get;}
    }
}
