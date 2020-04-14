using MicroBackend.Domain.Core.Log.Interfaces;
using MicroBackend.Domain.Core.Log.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroBackend.Domain.Core.Log.Logger
{
    public abstract class Logger : ILog
    {
        private readonly string _userName;
        private readonly string _message;
        private readonly string _data;
        private LogParameter _logParameter;

        public Logger(string username, string message, string data) : this(message, data)
        {
            _userName = username;
        }

        public Logger(string message, object data)
        {
            _message = message;
            _data = JsonConvert.SerializeObject(data);
        }

        public virtual void Error()
        {
            _logParameter = new LogParameter
            {
                Message = _message,
                TimeStamp = DateTime.Now,
                Username = _userName,
                Data = _data,
                LogTypeEnum = "Error"
            };
            WriteLog(_logParameter);
        }

        public virtual void Info()
        {
            _logParameter = new LogParameter
            {
                Message = _message,
                TimeStamp = DateTime.Now,
                Username = _userName,
                Data = _data,
                LogTypeEnum = "Info"
            };
            WriteLog(_logParameter);
        }

        public virtual void Warn()
        {
            _logParameter = new LogParameter
            {
                Message = _message,
                TimeStamp = DateTime.Now,
                Username = _userName,
                Data = _data,
                LogTypeEnum = "Warn"
            };
            WriteLog(_logParameter);
        }

        protected abstract void WriteLog(LogParameter logParameter);
    }
}
