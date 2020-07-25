using MicroBackend.User.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.User.Domain.Dtos
{
    public class LoginEmailAndPasswordDto : ILoginEmailAndPassword
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
