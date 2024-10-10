using FIAP._6NETT_GRUPO31.Domain.Entities;
using FIAP._6NETT_GRUPO31.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Infra.Data.Repository
{
    public class ContatoRepository:IContatoRepository
    {
        private readonly FIAPContext _context;

        public ContatoRepository(FIAPContext context)
        {
            _context = context;
        }

        public async Task<Boolean> AdicionaContato(Contatos contato)
        {
            _context.Add(contato);
             return await _context.SaveChangesAsync() > 0;            
        }

        public async Task AtualizaContato(Contatos contato)
        {
            _context.Contatos.Update(contato);
            await _context.SaveChangesAsync();         
        }

        public async Task<IEnumerable<Contatos>> ConsultaContatos(string ddd)
        {
            if (string.IsNullOrWhiteSpace(ddd)) return _context.Contatos;
            else return _context.Contatos.Where(x => x.DDDRegiao.Ddd == ddd).Include("DDDRegiao");
        }
    }
}
