using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Mongo.Models
{
    public abstract class MongoHelper
    {
        public IMongoDatabase Connection { get { return _connection; } }

        private readonly IMongoDatabase _connection;

        protected MongoHelper()
        {
            _connection = CreateConnection();
        }
        protected abstract IMongoDatabase CreateConnection();

    }
}
