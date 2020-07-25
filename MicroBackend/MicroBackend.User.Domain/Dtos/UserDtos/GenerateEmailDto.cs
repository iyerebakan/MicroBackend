using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.User.Domain.Dtos.UserDtos
{
    public class GenerateEmailDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string VerificationToken { get; set; }
    }
}
