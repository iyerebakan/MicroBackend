using MicroBackend.Domain.Core.Log.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroBackend.Domain.Core.Log.Logger
{
    public class FileLogger : Logger
    {
        public FileLogger(string message, object data) : base(message, data)
        {
        }

        public FileLogger(string username, string message, string data) : base(username, message, data)
        {
        }

        protected override void WriteLog(LogParameter logParameter)
        {
            var path = Configuration.GetSection("FileLogger").GetSection("FileLoggerPath").Value;
            List<string> list = new List<string>();
            list.Add(JsonConvert.SerializeObject(logParameter));

            File.AppendAllLinesAsync(path, list);
        }
    }
}
