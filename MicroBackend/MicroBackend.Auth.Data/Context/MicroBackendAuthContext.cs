using MicroBackend.Auth.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Auth.Data.Context
{
    public class MicroBackendAuthContext : IdentityDbContext<ApplicationUsers,ApplicationRoles,string>
    {
        public MicroBackendAuthContext(DbContextOptions options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUsers>(entity => { entity.ToTable(name: "Users"); });
            builder.Entity<ApplicationRoles>(entity => { entity.ToTable(name: "Roles"); });
            builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles"); });
            builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims"); });
            builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins"); });
            builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserTokens"); });
            builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaims"); });
        }
    }
}
