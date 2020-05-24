using MicroBackend.Auth.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Auth.Domain.Dtos
{
    public class LoginEmailDto : ILoginEmail
    {
        public string Email { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }
}
