using MicroBackend.Domain.Core.RabbitMq.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.RabbitMq.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
