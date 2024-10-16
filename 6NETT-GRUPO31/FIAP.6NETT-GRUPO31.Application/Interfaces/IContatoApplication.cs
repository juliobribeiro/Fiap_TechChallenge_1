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
        Task<Boolean> CadastrarContato(CadastrarContatoDto dto);
        Task<Boolean> AtualizarContrato(CadastrarContatoDto dto);
        Task<List<ContatoDto>> ConsultarContatosPorDDD(string ddd);
        Task<List<ContatoDto>> ConsultarTodosContatos();
    }
}
