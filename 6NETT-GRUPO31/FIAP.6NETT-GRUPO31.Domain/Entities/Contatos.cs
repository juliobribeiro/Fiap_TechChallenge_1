using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Domain.Entities
{
    public class Contatos
    {
        public int IdContato { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DDDRegiao IdDDDRegiao { get; set; }

        public Contatos(int idContato, string nome, string email, string telefone, DDDRegiao idDDDRegiao)
        {
            IdContato = idContato;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            IdDDDRegiao = idDDDRegiao;
        }
    }
}
