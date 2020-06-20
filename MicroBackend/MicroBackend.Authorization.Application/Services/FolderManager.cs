using MicroBackend.Authorization.Application.Interfaces;
using MicroBackend.Authorization.Data.Repository;
using MicroBackend.Authorization.Domain.Models;
using MicroBackend.Domain.Core.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Authorization.Application.Services
{
    public class FolderManager : IFolderService
    {
        private readonly FolderRepository _folderRepository;

        public FolderManager(FolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        public void Add(Folder folder)
        {
            _folderRepository.Add(folder);
        }

        public string FolderNameById(string Id)
        {
            return _folderRepository.GetById(Id)?.Name;
        }
    }
}
