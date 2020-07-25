using MicroBackend.Domain.Core.Mongo.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Mongo.Models
{
    public abstract class MongoEntity<T> : IMongoEntity<T>
    {
        public MongoEntity()
        {
            if (typeof(T) == typeof(string))
            {
                if (this._id == null)
                {
                    this._id = (T)(object)ObjectId.GenerateNewId().ToString();
                }
            }
        }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public T _id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

       
    }
}
