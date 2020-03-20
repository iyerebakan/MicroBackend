using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Auth.JWT.Models
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
