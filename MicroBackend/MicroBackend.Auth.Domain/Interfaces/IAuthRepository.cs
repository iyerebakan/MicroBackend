using MicroBackend.Auth.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Auth.Domain.Interfaces
{
    public interface IAuthRepository
    {
        void Login(LoginEmailAndPasswordDto instance);
        void ExternalLogin(LoginEmailDto instance);
    }
}
