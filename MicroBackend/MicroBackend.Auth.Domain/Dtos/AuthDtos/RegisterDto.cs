using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Auth.Domain.Dtos
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
