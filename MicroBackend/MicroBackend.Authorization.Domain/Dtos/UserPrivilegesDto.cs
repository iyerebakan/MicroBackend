using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Authorization.Domain.Dtos
{
    public class UserPrivilegesDto
    {
        public string UserId { get; set; }
        public List<FormUserDto> FormUserDtos { get; set; }
    }
}
