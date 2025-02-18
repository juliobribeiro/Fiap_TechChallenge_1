using Contact.Core.Dto;
using Contact.Core.Events;
using FIAP._6NETT_GRUPO31.Domain.Entities;
using FIAP._6NETT_GRUPO31.Domain.Interfaces;
using MassTransit;
using FIAP._6NETT_GRUPO31.Application.Utils;
using FIAP._6NETT_GRUPO31.Application.Interfaces;

namespace FIAP._6NETT_GRUPO31.Application.Consumers
{
    public class AddContactConsumer : IConsumer<AddContactEvent>
    {
        private readonly IContatoApplication _contatoApplication;

        public AddContactConsumer(IContatoApplication contatoApplication)
        {
            _contatoApplication = contatoApplication;
        }

        
        public async Task Consume(ConsumeContext<AddContactEvent> context)
        {            
            await _contatoApplication.CadastrarContato(Utils.Utils.MappingContatoEventToContatoDto(context.Message));
        }
       
    }
}
