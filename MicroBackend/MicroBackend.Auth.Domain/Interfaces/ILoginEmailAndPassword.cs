using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Auth.Domain.Interfaces
{
    interface ILoginEmailAndPassword : ILoginEmail
    {
        public string Password { get; set; }
    }
}
     