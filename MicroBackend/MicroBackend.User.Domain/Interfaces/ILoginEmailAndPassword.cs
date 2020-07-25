using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.User.Domain.Interfaces
{
    interface ILoginEmailAndPassword : ILoginEmail
    {
        public string Password { get; set; }
    }
}
     