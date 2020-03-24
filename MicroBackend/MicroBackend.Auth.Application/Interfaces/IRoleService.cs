using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroBackend.Auth.Application.Interfaces
{
    public interface IRoleService
    {
        Task<bool> CreateRole(string rolename);
    }
}
