using FIAP._6NETT_GRUPO31.Application.Dto;
using FIAP._6NETT_GRUPO31.Application.Interfaces;
using FIAP._6NETT_GRUPO31.Domain.Entities;
using FIAP._6NETT_GRUPO31.Infra.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Application.Services
{
    public class ContatoApplication : IContatoApplication
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoApplication(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<Boolean> CadastrarContato(CadastrarContatoDto dto)
        {

            var entidadeContato = new Contatos()
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone
            };

            var resultado = false;

            if (entidadeContato != null)
            {
                resultado = await _contatoRepository.AdicionaContato(entidadeContato);
            }

            return resultado;

        }

        public async Task<Boolean> AtualizarContrato(CadastrarContatoDto dto)
        {
            try
            {
                var entidadeContato = new Contatos()
                {
                    IdContato = dto.IdContato,
                    Nome = dto.Nome,
                    Email = dto.Email,
                    Telefone = dto.Telefone
                };
                await _contatoRepository.AtualizaContato(entidadeContato);

                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
            

        }

        public async Task<List<ContatoDto>> ConsultarContatosPorDDD(string ddd)
        {
            var listaContatoDto = new List<ContatoDto>();

            var listEntidade = await _contatoRepository.ConsultaContatos(ddd);

            foreach (var item in listEntidade)
            {
                ContatoDto dto = new ContatoDto()
                {
                    IdContato = item.IdContato,
                    Nome = item.Nome,
                    Email = item.Email,
                    Telefone = item.Telefone,
                    DDD = item.DDDRegiao.Ddd
                };

                listaContatoDto.Add(dto);
            }

            return listaContatoDto;
        }

        public async Task<List<ContatoDto>> ConsultarTodosContatos()
        {
            var listaContatoDto = new List<ContatoDto>();

            var ddd = string.Empty;

            var listEntidade = await _contatoRepository.ConsultaContatos(ddd);

            foreach (var item in listEntidade)
            {
                ContatoDto dto = new ContatoDto()
                {
                    IdContato = item.IdContato,
                    Nome = item.Nome,
                    Email = item.Email,
                    Telefone = item.Telefone,
                    DDD = item.DDDRegiao.Ddd
                };

                listaContatoDto.Add(dto);
            }

            return listaContatoDto;
        }
    }
}
