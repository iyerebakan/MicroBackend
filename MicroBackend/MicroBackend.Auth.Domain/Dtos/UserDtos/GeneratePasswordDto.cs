using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Auth.Domain.Dtos.UserDtos
{
    public class GeneratePasswordDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string VerificationToken { get; set; }
    }
}
