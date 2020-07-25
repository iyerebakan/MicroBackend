using MicroBackend.Auth.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Auth.Domain.Dtos.AuthDtos
{
    public class CheckPasswordDto
    {
        public ApplicationUsers ApplicationUsers { get; set; }
        public string Password { get; set; }
    }
}
