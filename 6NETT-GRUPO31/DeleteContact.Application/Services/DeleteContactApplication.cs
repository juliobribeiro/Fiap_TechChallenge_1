using Contact.Core.Events;
using DeleteContact.Application.Interfaces;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteContact.Application.Services
{
    public class DeleteContactApplication : IDeleteContactApplication
    {
        private readonly IBus _bus;

        public DeleteContactApplication(IBus bus)
        {
            _bus = bus;
        }

        public Task<bool> DeletarContato(int contatoId)
        {


            DeleteContactEvent deleteContactEvent = new DeleteContactEvent();
            deleteContactEvent.Id = contatoId;
            _bus.Publish(deleteContactEvent);

            return Task.FromResult(true);
        }
    }
}
