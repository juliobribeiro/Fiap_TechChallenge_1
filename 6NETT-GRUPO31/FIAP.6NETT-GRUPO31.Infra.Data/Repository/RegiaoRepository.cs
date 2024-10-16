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
    public class RegiaoRepository : IRegiaoRepository
    {
        private readonly FIAPContext _context;

        public RegiaoRepository(FIAPContext context)
        {
            _context = context;
        }
        public async Task<DDDRegiao> GetRegiaoPorDDD(string ddd)
        {
            return await _context.DDDRegiao.FirstOrDefaultAsync(x => x.Ddd.Equals(ddd));
        }
    }
}
