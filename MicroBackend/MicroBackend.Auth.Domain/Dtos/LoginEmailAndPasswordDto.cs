using MicroBackend.Auth.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Auth.Domain.Dtos
{
    public class LoginEmailAndPasswordDto : ILoginEmailAndPassword
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
