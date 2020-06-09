using MicroBackend.Authorization.Application.Interfaces;
using MicroBackend.Authorization.Domain.Dtos;
using MicroBackend.Authorization.Domain.Models;
using MicroBackend.Domain.Core.Mongo.Models;
using MicroBackend.Domain.Core.Services.Constants;
using MicroBackend.Domain.Core.Services.Interfaces;
using MicroBackend.Domain.Core.Services.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroBackend.Authorization.Application.Services
{
    public class UserPrivilegesManager : MongoRepositoryBase<UserPrivilege>, IUserPrivilegesService
    {
        private readonly IFolderService _folderService;
        private readonly IFormService _formService;
        public UserPrivilegesManager(
            MongoHelper mongoHelper,
            IFolderService folderService,
            IFormService formService
            ) : base(mongoHelper)
        {
            _folderService = folderService;
            _formService = formService;
        }

        public IServiceDataResult<UserPrivilegesDto> GetUserPrivilegesDto(string userId)
        {
            try
            {
                var userPrivileges = this.GetList(k => k.UserId == userId).ToList();
                if (userPrivileges.Count == 0)
                {
                    return new ErrorDataResult<UserPrivilegesDto>(GlobalErrors.NotAuthorization, "Kullanıcı yetkileri bulunamadı.");
                }
                var formUserDtos = new List<FormUserDto>();

                foreach (var privilege in userPrivileges)
                {
                    var form = _formService.GetById(privilege.FormId);
                    var folder = _folderService.GetById(form.FolderId);

                    formUserDtos.Add(new FormUserDto
                    {
                        UserId = userId,
                        FormId = form._id,
                        FolderName = folder.Name,
                        FormName = form.Name
                    });
                }

                var userPrivilegesDto = new UserPrivilegesDto()
                {
                    UserId = userId,
                    FormUserDtos = formUserDtos
                };

                return new SuccessDataResult<UserPrivilegesDto>(userPrivilegesDto);
            }
            catch(Exception ex)
            {
                return new ErrorDataResult<UserPrivilegesDto>(GlobalErrors.UnknownError, ex.Message);
            }
            
        }
    }
}
