using MicroBackend.Domain.Core.Mongo.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MicroBackend.Authorization.Application.DbHelper
{
    public class MongoDbHelper : MongoHelper
    {

        protected override IMongoDatabase CreateConnection()
        {
            IConfigurationRoot ConfigurationRoot = null;
            var configurationBuilder = new ConfigurationBuilder();
            string appsettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(appsettingsPath, false);

            ConfigurationRoot = configurationBuilder.Build();


            var mongoClient = new MongoClient(ConfigurationRoot.GetSection("MongoConnection").GetSection("ConnectionString").Value);
            return mongoClient.GetDatabase(ConfigurationRoot.GetSection("MongoConnection").GetSection("Database").Value);
        }
    }
}
