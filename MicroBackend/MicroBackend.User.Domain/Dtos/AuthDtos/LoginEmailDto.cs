using MicroBackend.User.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.User.Domain.Dtos
{
    public class LoginEmailDto : ILoginEmail
    {
        public string Email { get; set; }
    }
}
