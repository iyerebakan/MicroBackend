using MicroBackend.Authorization.Domain.Models;
using MicroBackend.Domain.Core.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Authorization.Data.Repository
{
    public class FolderRepository : MongoRepositoryBase<Folder>
    {
        public FolderRepository(MongoHelper mongoHelper) : base(mongoHelper)
        {
        }
    }
}
