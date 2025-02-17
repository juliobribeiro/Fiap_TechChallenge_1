using Contact.Core.Dto;
using Contact.Core.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateContact.Application.Interfaces;

namespace UpdateContact.Application.Services
{
    public class UpdateContactApplication : IUpdateContactApplication
    {
        private readonly IBus _bus;

        public UpdateContactApplication(IBus bus)
        {
            _bus = bus;
        }

        public Task<bool> AtualizarContrato(int contatoId, CadastrarAtualizarContatoDto dto)
        {
            //validar contato

            UpdateContactEvent updateContactEvent = new UpdateContactEvent();
            _bus.Publish(updateContactEvent);

            return Task.FromResult(true);
        }
    }
}
