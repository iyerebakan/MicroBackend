using Dapper;
using MicroBackend.Domain.Core.Log.Interfaces;
using MicroBackend.Domain.Core.Log.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroBackend.Domain.Core.Log.Logger
{
    public class DatabaseLogger : Logger
    {
        private static IConfigurationRoot _configuration;
        public static IConfigurationRoot Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    var configurationBuilder = new ConfigurationBuilder();
                    string appsettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                    configurationBuilder.AddJsonFile(appsettingsPath, false);

                    _configuration = configurationBuilder.Build();
                }

                return _configuration;
            }
        }

        public DatabaseLogger(string message, object data) : base(message, data)
        {
        }

        public DatabaseLogger(string username, string message, string data) : base(username, message, data)
        {
        }

        protected override void WriteLog(LogParameter logParameter)
        {
            string sql = "INSERT INTO [dbo].[Logs]([Detail],[Timestamp],[Audit],[Message],[Username]) values (@Detail,@Timestamp,@Audit,@Message,@Username)";
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DatabaseLoggerConnection")))
            {
                var affectedRows = connection.ExecuteAsync(sql,
                    new
                    {
                        Detail = logParameter.Data,
                        Timestamp = logParameter.TimeStamp,
                        Audit = logParameter.LogTypeEnum,
                        Message = logParameter.Message,
                        Username = logParameter.Username
                    }).Result;

            }
        }
    }
}
