using MicroBackend.Authorization.Domain.Dtos;
using MicroBackend.Authorization.Domain.Models;
using MicroBackend.Domain.Core.Mongo.Interfaces;
using MicroBackend.Domain.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroBackend.Authorization.Application.Interfaces
{
    public interface IUserPrivilegesService
    {
        IServiceDataResult<UserPrivilegesDto>  GetUserPrivilegesDto(string userId);
    }
}
