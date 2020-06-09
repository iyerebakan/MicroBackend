using MicroBackend.Domain.Core.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Authorization.Domain.Models
{
    public class UserPrivilege : MongoEntity<string>
    {
        public string UserId { get; set; }
        public string FormId { get; set; }
    }
}
