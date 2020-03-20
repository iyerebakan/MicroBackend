using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroBackend.Auth.JWT.Models;
using MicroBackend.Auth.Data.Context;
using MicroBackend.Auth.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MicroBackend.Auth.JWT.Services.Encryption;
using MicroBackend.Domain.Core.Utilities.Security.Token;
using MicroBackend.Auth.JWT.Services.Jwt;
using MicroBackend.Auth.Application.Interfaces;
using MicroBackend.Auth.Application.Services;
using MicroBackend.Auth.Data.Repository;

namespace MicroBackend.Auth.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
       {
            services.AddScoped<ITokenHelper, JwtService>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<AuthRepository>();

            services.AddDbContext<MicroBackendAuthContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MicroBackendAuthConnection"));
            });

            services.AddIdentity<ApplicationUsers, IdentityRole>().AddEntityFrameworkStores<MicroBackendAuthContext>();
            services.AddControllers();

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<JWT.Models.TokenOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
