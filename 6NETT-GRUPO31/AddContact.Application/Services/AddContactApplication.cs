using AddContact.Application.Interfaces;
using Contact.Core.Dto;
using Contact.Core.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddContact.Application.Services
{
    public class AddContactApplication : IAddContactApplication
    {
        private readonly IBus _bus;

        public AddContactApplication(IBus bus)
        {
            _bus = bus;
        }

        public Task<bool> CadastrarContato(CadastrarAtualizarContatoDto dto)
        {
            // validar email


            AddContactEvent contactEvent = new AddContactEvent();
            _bus.Publish(contactEvent);
            return Task.FromResult(true);
        }
    }
}
