using MicroBackend.User.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.User.Data.Repository
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
