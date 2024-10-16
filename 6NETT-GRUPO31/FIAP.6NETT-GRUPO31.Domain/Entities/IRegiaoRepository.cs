using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Domain.Entities
{
    public interface IRegiaoRepository
    {
        Task<DDDRegiao> GetRegiaoPorDDD(string ddd);

        Task<List<DDDRegiao>> GetRegioes();

    }
}
