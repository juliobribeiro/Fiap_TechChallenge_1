using Contact.Core.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Application.Consumers
{
    class AddContactConsumer : IConsumer<AddContactEvent>
    {
        public Task Consume(ConsumeContext<AddContactEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
