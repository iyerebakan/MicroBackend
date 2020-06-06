using MicroBackend.Domain.Core.Mongo.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Mongo.Models
{
    public abstract class MongoEntity<T> : IMongoEntity<T>
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public T _id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public MongoEntity()
        {

        }
        public MongoEntity(bool create)
        {
            if (create)
            {
                if (typeof(T) == typeof(string))
                {
                    this._id = (T)(object)Guid.NewGuid().ToString();
                }
                else if (typeof(T) == typeof(Guid))
                {
                    this._id = (T)(object)Guid.NewGuid();
                }
            }
        }
    }
}
