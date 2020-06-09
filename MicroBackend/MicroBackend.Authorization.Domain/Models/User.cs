using MicroBackend.Domain.Core.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Authorization.Domain.Models
{
    public class User : MongoEntity<string>
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
