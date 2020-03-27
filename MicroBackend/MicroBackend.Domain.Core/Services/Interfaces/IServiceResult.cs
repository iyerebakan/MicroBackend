using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Services.Interfaces
{
    public interface IServiceResult
    {
        int Code { get; }
        string Message { get; }
        bool Success { get; }
    }
}
