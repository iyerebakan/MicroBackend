using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Security.Token
{
    public class AccessToken : TokenInfo
    {
        public AccessToken(TokenInfo tokenInfo)
        {
            this.Email = tokenInfo.Email;
            this.Id = tokenInfo.Id;
            this.Roles = tokenInfo.Roles;
            this.UserName = tokenInfo.UserName;
        }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
