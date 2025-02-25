using Contact.Core.Dto;
using GetContact.Application.Interfaces;
using GetContact.Domain.Entities;
using GetContact.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetContact.Application.Services
{
    public class ContatoApplication : IContatoApplication
    {
        private readonly IGetContactRepository _contatoRepository;

        public ContatoApplication(IGetContactRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
             
        public async Task<List<ContatoDto>> ConsultarContatosPorDDD(int ddd)
        {
            var listaContatoDto = new List<ContatoDto>();

            var listEntidade = await _contatoRepository.ConsultaContatos(ddd);

            return MappingContatosToContatoDto(listEntidade.ToList());
        }

        public async Task<List<ContatoDto>> ConsultarTodosContatos()
        {

            var listEntidade = await _contatoRepository.ConsultaContatos(0);

            return MappingContatosToContatoDto(listEntidade.ToList());
        }
  

        private List<ContatoDto> MappingContatosToContatoDto(List<Contatos> contatos)
        {
            var listaContatoDto = new List<ContatoDto>();

            foreach (var item in contatos)
            {
                ContatoDto dto = new ContatoDto()
                {
                    IdContato = item.IdContato,
                    Nome = item.Nome,
                    Email = item.Email,
                    Telefone = item.Telefone,
                    DDD = item.DDD
                };

                listaContatoDto.Add(dto);
            }

            return listaContatoDto;
        }

        private Contatos MappingContatoDtoToContato(CadastrarAtualizarContatoDto dto)
        {
            var entidadeContato = new Contatos()
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone,
                DDD = dto.DDD
            };

            return entidadeContato;
        }

        private async Task<bool> ExisteEmailCadastrado(string email)
        {
            var contato = await _contatoRepository.ConsultarContatoPorEmail(email);

            return contato != null;

        }


    }
}
