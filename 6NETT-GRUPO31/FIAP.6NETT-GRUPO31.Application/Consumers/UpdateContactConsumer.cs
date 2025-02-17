using Contact.Core.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Application.Consumers
{
    public class UpdateContactConsumer : IConsumer<UpdateContactConsumer>
    {
        public Task Consume(ConsumeContext<UpdateContactConsumer> context)
        {
            throw new NotImplementedException();
        }
    }
}
