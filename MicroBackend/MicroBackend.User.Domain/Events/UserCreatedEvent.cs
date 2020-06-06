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
        public string _Id { get; set; }

        public UserCreatedEvent(string  username,string email,string id)
        {
            Username = username;
            Email = email;
            _Id = id;
        }
    }
}
