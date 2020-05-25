using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.User.Domain.Commands
{
    public class CreatedUserCommand : UserCommand
    {
        public CreatedUserCommand(string username,string email)
        {
            Email = email;
            Username = username;
        }
    }
}
