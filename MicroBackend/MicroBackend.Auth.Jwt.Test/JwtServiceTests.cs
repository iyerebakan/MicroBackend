using FluentAssertions;
using MicroBackend.Auth.JWT.Security.Token;
using MicroBackend.Auth.JWT.Services.Jwt;
using Xunit;

namespace MicroBackend.Auth.Jwt.Test
{
    public class JwtServiceTests
    {
        [Theory]
        [InlineData("ec1d6db5-ea91-489a-bf9b-50e7da04eb8f", "iyerebakan", "iboyrebakan@gmail.com", new string[] { "testRole" })]
        public void CreateJwtToken_ShoulBeTrue_WithTokenInfo(string id, string username, string email, string[] roles)
        {
            var tokenInfo = new TokenInfo
            {
                Email = email,
                Id = id,
                Roles = roles,
                UserName = username
            };

            var token = new JwtService().CreateToken(tokenInfo);

            token.Should().NotBeNull();
        }
    }
}
