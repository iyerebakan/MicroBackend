using MicroBackend.Domain.Core.Mongo.Interfaces;
using MicroBackend.Domain.Core.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Authorization.Application.Services
{
    public class BaseManager<T> : MongoRepositoryBase<T> where T : class, IMongoEntity, new()
    {
        public BaseManager(MongoHelper mongoHelper) : base(mongoHelper)
        {
        }
    }
}
