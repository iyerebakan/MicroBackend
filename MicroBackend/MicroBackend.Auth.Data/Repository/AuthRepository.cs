using MicroBackend.Auth.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Auth.Data.Repository
{
    public class AuthRepository : UserManager<ApplicationUsers>
    {
        public AuthRepository(IUserStore<ApplicationUsers> store, IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<ApplicationUsers> passwordHasher, IEnumerable<IUserValidator<ApplicationUsers>> userValidators, 
            IEnumerable<IPasswordValidator<ApplicationUsers>> passwordValidators, ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<ApplicationUsers>> logger)
                : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
    }
}
