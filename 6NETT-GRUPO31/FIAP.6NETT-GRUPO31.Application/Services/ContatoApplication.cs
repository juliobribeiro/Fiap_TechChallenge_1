using FIAP._6NETT_GRUPO31.Application.Dto;
using FIAP._6NETT_GRUPO31.Application.Interfaces;
using FIAP._6NETT_GRUPO31.Domain.Entities;

namespace FIAP._6NETT_GRUPO31.Application.Services
{
    public class ContatoApplication : IContatoApplication
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoApplication(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<Boolean> CadastrarContato(CadastrarAtualizarContatoDto dto)
        {
            var resultado = false;            

            if (dto != null)
            {
                if (await ExisteEmailCadastrado(dto.Email)) throw new Exception($"O email {dto.Email} já está sendo usando para outro contato");

                resultado = await _contatoRepository.AdicionaContato(MappingContatoDtoToContato(dto));
            }

            return resultado;

        }

        public async Task<Boolean> AtualizarContrato(int contatoId,CadastrarAtualizarContatoDto dto)
        {
            try
            {
                var contatoUpdate = await _contatoRepository.ConsultarContatoPorId(contatoId);              

                if (contatoUpdate is null) throw new Exception($"Contato com  id:{contatoId} não encontrado");

                if (contatoUpdate.Email != dto.Email)
                {
                    if (await ExisteEmailCadastrado(dto.Email)) throw new Exception($"O email {dto.Email} já está sendo usando para outro contato");
                }

                contatoUpdate.Email = dto.Email;
                contatoUpdate.Telefone = dto.Telefone;
                contatoUpdate.Nome = dto.Nome;
                contatoUpdate.DDD = dto.DDD;

                await _contatoRepository.AtualizaContato(contatoUpdate);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
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

        public async Task<bool> DeletarContato(int contatoId)
        {
            var contatoDelete = await _contatoRepository.ConsultarContatoPorId(contatoId);

            if (contatoDelete is null) throw new Exception($"Contato com id:{contatoId} não encontrado");

            await _contatoRepository.DeletarContato(contatoDelete);

            return true;


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
