using Contact.Core.Dto;
using FIAP._6NETT_GRUPO31.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Application.Interfaces
{
    public interface IContatoApplication
    {
        Task<Boolean> CadastrarContato(CadastrarAtualizarContatoDto dto);
        Task<Boolean> AtualizarContrato(int contatoId, CadastrarAtualizarContatoDto dto);
        Task<List<ContatoDto>> ConsultarContatosPorDDD(int ddd);
        Task<List<ContatoDto>> ConsultarTodosContatos();
        Task<Boolean> DeletarContato(int contatoId);
    }
}
