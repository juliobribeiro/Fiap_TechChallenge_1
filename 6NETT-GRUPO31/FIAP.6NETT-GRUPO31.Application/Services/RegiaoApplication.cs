using FIAP._6NETT_GRUPO31.Application.Dto;
using FIAP._6NETT_GRUPO31.Application.Interfaces;
using FIAP._6NETT_GRUPO31.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Application.Services
{
    public class RegiaoApplication : IRegiaoApplication
    {
        private readonly IRegiaoRepository _regiaoRepository;

        public RegiaoApplication(IRegiaoRepository regiaoRepository)
        {
            _regiaoRepository = regiaoRepository;
        }

        public async Task<DDDRegiaoDto> GetRegiaoPorDDD(string ddd)
        {
            if (string.IsNullOrWhiteSpace(ddd)) throw new Exception("Informe o DDD");

            var regiao = await _regiaoRepository.GetRegiaoPorDDD(ddd);

            if (regiao == null) throw new Exception($"O DDDD {ddd} não existe");

            return new DDDRegiaoDto()
            {
                IdDDDRegiao = regiao.IdDDDRegiao,
                Cidade = regiao.Cidade,
                Ddd = regiao.Ddd,
                UF = regiao.UF,
                Regiao = regiao.Regiao                
            };
        }

        public async Task<List<DDDRegiaoDto>> GetRegioes()
        {
            var regioes = await _regiaoRepository.GetRegioes();

            var ret = new List<DDDRegiaoDto>();

            foreach (var regiao in regioes)
            {
                ret.Add(new DDDRegiaoDto()
                {
                    IdDDDRegiao = regiao.IdDDDRegiao,
                    Cidade = regiao.Cidade,
                    Ddd = regiao.Ddd,
                    UF = regiao.UF,
                    Regiao = regiao.Regiao
                });
            }

            return ret;

        }
    }
}
