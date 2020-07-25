using MicroBackend.User.Application.Interfaces;
using MicroBackend.User.Data.Repository;
using MicroBackend.User.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroBackend.User.Application.Services
{
    public class RoleManager : IRoleService
    {
        private readonly RoleRepository _roleRepository;
        public RoleManager(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<bool> CreateRole(string rolename)
        {
            var role =  await _roleRepository.CreateAsync(new ApplicationRoles { Name = rolename });
            if (role.Succeeded)
            {
                return true;
            }

            return false;
        }
    }
}
