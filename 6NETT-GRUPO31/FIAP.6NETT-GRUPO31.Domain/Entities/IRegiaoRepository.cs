﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Domain.Entities
{
    public interface IRegiaoRepository
    {
        public Task<DDDRegiao> GetRegiaoPorDDD(string ddd);

        public Task<List<DDDRegiao>> GetRegioes();

    }
}
