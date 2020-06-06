using MicroBackend.Authorization.Application.Events;
using MicroBackend.Authorization.Application.Interfaces;
using MicroBackend.Authorization.Domain.Models;
using MicroBackend.Domain.Core.RabbitMq.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroBackend.Authorization.Application.EventHandlers
{
    public class UserEventHandler : IEventHandler<UserCreatedEvent>
    {
        private readonly IUserService _transferRepository;

        public UserEventHandler(IUserService transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public Task Handle(UserCreatedEvent @event)
        {
            _transferRepository.AddAsync(new User()
            {
                Username = @event.Username,
                Email = @event.Email,
                _id = @event._Id
            });

            return Task.CompletedTask;
        }
    }
}
