using MicroBackend.Auth.Data.Context;
using MicroBackend.Auth.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Auth.Data.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly MicroBackendAuthContext _microBackendAuthContext;
        public AuthRepository(MicroBackendAuthContext microBackendAuthContext)
        {
            _microBackendAuthContext = microBackendAuthContext;
        }

        public void ExternalLogin(LoginEmailDto instance)
        {
            //_microBackendAuthContext.ex
        }

        public void Login(LoginEmailAndPasswordDto instance)
        {
            throw new NotImplementedException();
        }
    }
}
