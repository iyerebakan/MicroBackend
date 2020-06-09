using MicroBackend.Domain.Core.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Authorization.Domain.Models
{
    public class Folder : MongoEntity<string>
    {
        public Folder()
        {
            this.Locked = true;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MasterFolderId { get; set; }
        public bool Locked { get; set; }
    }
}
