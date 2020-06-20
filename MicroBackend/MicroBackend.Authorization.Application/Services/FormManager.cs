using MicroBackend.Authorization.Application.Interfaces;
using MicroBackend.Authorization.Data.Repository;
using MicroBackend.Authorization.Domain.Dtos;
using MicroBackend.Authorization.Domain.Models;
using MicroBackend.Domain.Core.Mongo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroBackend.Authorization.Application.Services
{
    public class FormManager : IFormService
    {
        private readonly FormRepository _formRepository;
        private readonly IFolderService _folderService;

        public FormManager(FormRepository formRepository, IFolderService folderService)
        {
            _formRepository = formRepository;
            _folderService = folderService;
        }

        public void Add(Form form)
        {
            _formRepository.Add(form);
        }

        public List<FormListDto> GetList()
        {
            return _formRepository.GetList().Select(g => new FormListDto
            {
                FormId = g._id,
                FormName = g.Name,
                FolderName = _folderService.FolderNameById(g.FolderId)
            }).ToList();
        }
    }
}
