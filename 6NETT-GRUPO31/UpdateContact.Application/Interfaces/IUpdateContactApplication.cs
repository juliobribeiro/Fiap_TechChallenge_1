using Contact.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateContact.Application.Interfaces
{
   public interface IUpdateContactApplication
    {
        Task<Boolean> AtualizarContrato(int contatoId, CadastrarAtualizarContatoDto dto);
    }
}
