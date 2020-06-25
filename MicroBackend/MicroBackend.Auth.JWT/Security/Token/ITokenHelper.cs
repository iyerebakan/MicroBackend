using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Auth.JWT.Security.Token
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(TokenInfo tokenInfo);
    }
}
