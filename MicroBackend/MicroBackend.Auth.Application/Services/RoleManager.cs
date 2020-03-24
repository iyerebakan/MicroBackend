using MicroBackend.Auth.Application.Interfaces;
using MicroBackend.Auth.Data.Repository;
using MicroBackend.Auth.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroBackend.Auth.Application.Services
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
