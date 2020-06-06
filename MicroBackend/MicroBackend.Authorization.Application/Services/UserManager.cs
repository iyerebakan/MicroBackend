using MicroBackend.Authorization.Application.Interfaces;
using MicroBackend.Authorization.Domain.Models;
using MicroBackend.Domain.Core.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Authorization.Application.Services
{
    public class UserManager : MongoRepositoryBase<User>, IUserService
    {
        public UserManager(MongoHelper mongoHelper) : base(mongoHelper)
        {
        }
    }
}
