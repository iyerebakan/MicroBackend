using MicroBackend.Domain.Core.RabbitMq.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.User.Domain.Commands
{
    public class UserCommand : Command
    {
        public string Username { get; protected set; }
        public string Email { get; protected set; }
        public string _Id { get; protected set; }
    }
}
