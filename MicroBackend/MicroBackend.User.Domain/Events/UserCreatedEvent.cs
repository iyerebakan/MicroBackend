using MicroBackend.Domain.Core.RabbitMq.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.User.Domain.Events
{
    public class UserCreatedEvent : Event
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public UserCreatedEvent(string  username,string email)
        {
            Username = username;
            Email = email;
        }
    }
}
