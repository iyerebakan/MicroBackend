using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Security.Token
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(TokenInfo tokenInfo);
    }
}
