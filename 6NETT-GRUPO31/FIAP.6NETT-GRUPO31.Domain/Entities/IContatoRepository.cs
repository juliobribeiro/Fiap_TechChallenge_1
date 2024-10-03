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

        Task<IEnumerable<Contatos>> ConsultaContatos(string ddd);

        Task AtualizaContato(int idContato, Contatos contato);
    }
}
