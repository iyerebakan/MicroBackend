using MicroBackend.Domain.Core.RabbitMq.Bus;
using MicroBackend.Domain.Core.RabbitMq.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Authorization.Application.Events
{
    public class UserCreatedEvent : Event
    {
        public string _Id { get; set; }
        public string Username { get; private set; }
        public string Email { get; private set; }

        public UserCreatedEvent(string username, string email,string Id)
        {
            _Id = Id;
            Username = username;
            Email = email;
        }
    }
}
