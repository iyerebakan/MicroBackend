using MediatR;
using MicroBackend.Domain.Core.RabbitMq.Bus;
using MicroBackend.User.Domain.Commands;
using MicroBackend.User.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroBackend.User.Domain.CommandHandlers
{
    public class UserCommandHandler : IRequestHandler<CreatedUserCommand, bool>
    {
        private readonly IEventBus _bus;

        public UserCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreatedUserCommand request, CancellationToken cancellationToken)
        {
            //publish event to RabbitMQ
            _bus.Publish(new UserCreatedEvent(request.Username, request.Email,request._Id));

            return Task.FromResult(true);
        }
    }
}
