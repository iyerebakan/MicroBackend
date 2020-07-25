using MicroBackend.Authorization.Application.Interfaces;
using MicroBackend.Authorization.Data.Repository;
using MicroBackend.Authorization.Domain.Dtos;
using MicroBackend.Authorization.Domain.Models;
using MicroBackend.Domain.Core.Cache.Interfaces;
using MicroBackend.Domain.Core.Mongo.Models;
using MongoDB.Bson.IO;
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
        private readonly ICacheService _cacheService;

        public FormManager(FormRepository formRepository, IFolderService folderService, ICacheService cacheService)
        {
            _formRepository = formRepository;
            _folderService = folderService;
            _cacheService = cacheService;
        }

        public void Add(Form form)
        {
            _formRepository.Add(form);
        }

        public List<FormListDto> GetList()
        {
            _cacheService.RemoveCacheAsync("listOfForms1");
            string cache = _cacheService.GetCacheValueAsync("listOfForms").Result;
            var list = new List<FormListDto>();
            if (cache != null)
            {
                list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FormListDto>>(cache);
            }
            else
            {
                list = _formRepository.GetList().Select(g => new FormListDto
                {
                    FormId = g._id,
                    FormName = g.Name,
                    FolderName = _folderService.FolderNameById(g.FolderId)
                }).ToList();
            }
            

            _cacheService.SetCacheValueAsync("listOfForms",Newtonsoft.Json.JsonConvert.SerializeObject(list).ToString());

            return list;
        }
    }
}
