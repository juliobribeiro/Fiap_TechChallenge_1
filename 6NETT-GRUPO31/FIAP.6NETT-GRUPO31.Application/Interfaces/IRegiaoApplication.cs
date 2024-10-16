using FIAP._6NETT_GRUPO31.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Application.Interfaces
{
    public interface IRegiaoApplication
    {
        Task<DDDRegiaoDto> GetRegiaoPorDDD(string ddd);
    }
}
