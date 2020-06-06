using MicroBackend.Authorization.Application.Interfaces;
using MicroBackend.Authorization.Domain.Models;
using MicroBackend.Domain.Core.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Authorization.Application.Services
{
    public class FolderManager : MongoRepositoryBase<Folder>, IFolderService
    {
        public FolderManager(MongoHelper mongoHelper) : base(mongoHelper)
        {
        }
    }
}
