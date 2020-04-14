using MicroBackend.Domain.Core.Log.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroBackend.Domain.Core.Log.Interfaces
{
    public interface ILog
    {
        void Info();
        void Warn();
        void Error();
    }
}
