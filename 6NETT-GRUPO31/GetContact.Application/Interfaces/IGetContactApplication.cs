using Contact.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetContact.Application.Interfaces
{
    public interface IContatoApplication
    {

        Task<List<ContatoDto>> ConsultarContatosPorDDD(int ddd);
        Task<List<ContatoDto>> ConsultarTodosContatos();        
    }
}
