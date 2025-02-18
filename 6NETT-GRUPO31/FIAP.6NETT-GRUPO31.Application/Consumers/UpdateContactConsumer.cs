using Contact.Core.Events;
using FIAP._6NETT_GRUPO31.Application.Interfaces;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Application.Consumers
{
    public class UpdateContactConsumer : IConsumer<UpdateContactEvent>
    {
        private readonly IContatoApplication contatoApplication;

        public UpdateContactConsumer(IContatoApplication contatoApplication)
        {
            this.contatoApplication = contatoApplication;
        }

        public async Task Consume(ConsumeContext<UpdateContactEvent> context)
        {
            await contatoApplication.AtualizarContrato(context.Message.Id, Utils.Utils.MappingContatoEventToContatoDto(context.Message));            
        }
    }
}
