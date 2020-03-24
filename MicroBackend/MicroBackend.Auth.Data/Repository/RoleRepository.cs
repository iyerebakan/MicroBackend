using MicroBackend.Auth.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Auth.Data.Repository
{
    public class RoleRepository : RoleManager<ApplicationRoles>
    {
        public RoleRepository(IRoleStore<ApplicationRoles> store, IEnumerable<IRoleValidator<ApplicationRoles>> roleValidators, 
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<ApplicationRoles>> logger) 
            : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
