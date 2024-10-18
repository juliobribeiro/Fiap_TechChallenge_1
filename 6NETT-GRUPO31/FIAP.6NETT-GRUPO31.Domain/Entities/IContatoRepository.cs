using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Domain.Entities
{
    public interface IContatoRepository
    {
        Task<Boolean> AdicionaContato(Contatos contato);
        Task<IEnumerable<Contatos>> ConsultaContatos(int ddd);
        Task AtualizaContato(Contatos contato);
        Task<Contatos> ConsultarContatoPorId(int IdContato);
        Task<Boolean> DeletarContato(Contatos contato);
        Task<Contatos> ConsultarContatoPorEmail(string email);
    }
}
