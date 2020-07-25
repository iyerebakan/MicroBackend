using MicroBackend.Authorization.Application.Interfaces;
using MicroBackend.Authorization.Data.Repository;
using MicroBackend.Authorization.Domain.Models;
using MicroBackend.Domain.Core.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroBackend.Authorization.Application.Services
{
    public class UserManager : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserManager(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }
    }
}
