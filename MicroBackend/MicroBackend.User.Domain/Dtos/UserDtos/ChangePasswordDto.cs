using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.User.Domain.Dtos.UserDtos
{
    public class ChangePasswordDto
    {
        public string Email { get; set; }
        public string VerificationToken { get; set; }
        public string NewPassword { get; set; }
    }
}
