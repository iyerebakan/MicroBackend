using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Mongo.Interfaces
{
    public interface IMongoEntity
    {

    }
    public interface IMongoEntity<T> : IMongoEntity
    {
        DateTime CreateDate { get; set; }
        DateTime? ModifyDate { get; set; }

    }
}
