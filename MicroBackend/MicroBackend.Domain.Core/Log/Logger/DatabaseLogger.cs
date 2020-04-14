using MicroBackend.Domain.Core.Log.Interfaces;
using MicroBackend.Domain.Core.Log.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroBackend.Domain.Core.Log.Logger
{
    public class DatabaseLogger : Logger
    {
        public DatabaseLogger(string message, object data) : base(message, data)
        {
        }

        public DatabaseLogger(string username, string message, string data) : base(username, message, data)
        {
        }

        protected override void WriteLog(LogParameter logParameter)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=AuthenticationDb;User ID=sa;Password=#1q2w3e#;MultipleActiveResultSets=true");
            SqlCommand sqlCommand = new SqlCommand($"exec Prc_Test123", conn);
            conn.Open();
            sqlCommand.StatementCompleted += QueryStatementCompletedEventHandler;
            var result = sqlCommand.ExecuteNonQueryAsync(CancellationToken.None);
            conn.Close();
        }

        private void QueryStatementCompletedEventHandler(object sender, StatementCompletedEventArgs e)
        {
            
        }
    }
}
