using MicroBackend.Auth.Domain.Models;
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
        }
    }
}
