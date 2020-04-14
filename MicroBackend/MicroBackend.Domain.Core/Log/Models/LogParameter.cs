using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Log.Models
{
    public class LogParameter
    {
        public string Username { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public string LogTypeEnum { get; set; }
        public object Data { get; set; }
    }
}
