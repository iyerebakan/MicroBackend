using MediatR;
using MicroBackend.Domain.Core.RabbitMq.Bus;
using MicroBackend.Domain.Core.RabbitMq.Infrastructures;
using MicroBackend.User.Domain.CommandHandlers;
using MicroBackend.User.Domain.Commands;
using MicroBackend.User.Domain.Events;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MicroBackend.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });



            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreatedUserCommand, bool>, UserCommandHandler>();
        }
    }
}
