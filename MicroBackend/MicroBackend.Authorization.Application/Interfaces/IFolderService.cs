using MicroBackend.Authorization.Domain.Models;
using MicroBackend.Domain.Core.Mongo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Authorization.Application.Interfaces
{
    public interface IFolderService
    {
        void Add(Folder folder);
        string FolderNameById(string Id);
    }
}
