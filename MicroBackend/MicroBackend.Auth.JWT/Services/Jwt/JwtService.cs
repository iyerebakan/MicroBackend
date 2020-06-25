using MicroBackend.Auth.JWT.Models;
using MicroBackend.Auth.JWT.Security.Token;
using MicroBackend.Auth.JWT.Services.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;


namespace MicroBackend.Auth.JWT.Services.Jwt
{
    public class JwtService : ITokenHelper
    {
        public IConfigurationRoot Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtService()
        {
            var configurationBuilder = new ConfigurationBuilder();
            string appsettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(appsettingsPath, false);

            Configuration = configurationBuilder.Build();
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(TokenInfo tokenInfo)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, tokenInfo, signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken(tokenInfo)
            {
                Token = token,
                Expiration = _accessTokenExpiration,

            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, TokenInfo tokenInfo,
            SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(tokenInfo),
                signingCredentials: signingCredentials
            );

            return jwt;
        }

        private IEnumerable<Claim> SetClaims(TokenInfo tokenInfo)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(MicroBackendClaimTypes.Email, tokenInfo.Email));
            claims.Add(new Claim(MicroBackendClaimTypes.UserId, tokenInfo.Id.ToString()));
            claims.Add(new Claim(MicroBackendClaimTypes.UserName, tokenInfo.UserName));

            tokenInfo.Roles.ToList().ForEach(role => claims.Add(new Claim(MicroBackendClaimTypes.Role, role)));

            return claims;
        }


    }
}
