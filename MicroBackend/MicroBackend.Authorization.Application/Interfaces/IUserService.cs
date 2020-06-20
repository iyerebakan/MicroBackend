using MicroBackend.Authorization.Domain.Models;
using MicroBackend.Domain.Core.Mongo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroBackend.Authorization.Application.Interfaces
{
    public interface IUserService 
    {
        Task AddAsync(User user);
    }
}
