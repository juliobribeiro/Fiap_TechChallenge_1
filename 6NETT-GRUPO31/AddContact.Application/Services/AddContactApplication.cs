using AddContact.Application.Interfaces;
using Contact.Core.Dto;
using Contact.Core.Events;
using FIAP._6NETT_GRUPO31.Domain.Entities;
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

        public async  Task<bool> CadastrarContato(CadastrarAtualizarContatoDto dto)
        {
            // validar email


            AddContactEvent contactEvent = new AddContactEvent();
            contactEvent.Nome = dto.Nome;
            contactEvent.Email = dto.Email;
            contactEvent.Telefone = dto.Telefone;
            contactEvent.DDD = dto.DDD;
            await _bus.Publish(contactEvent);

            return true;
        
        }

        

    }
}
