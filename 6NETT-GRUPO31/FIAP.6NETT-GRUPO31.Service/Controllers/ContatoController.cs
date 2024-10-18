using FIAP._6NETT_GRUPO31.Application.Dto;
using FIAP._6NETT_GRUPO31.Application.Interfaces;
using FIAP._6NETT_GRUPO31.Service.Model;
using Microsoft.AspNetCore.Mvc;

namespace FIAP._6NETT_GRUPO31.Service.Controllers
{    

    [ApiController]
    public class ContatoController : MainController
    {
        private readonly IContatoApplication _contatoApplication;
        public ContatoController(IContatoApplication contatoApplication)
        {
            _contatoApplication = contatoApplication;
        }

        [HttpGet("/contatos")]
        [ProducesResponseType(typeof(List<ContatoModel>), StatusCodes.Status200OK)]        
        public async Task<IActionResult> ConsultarContatos()
        {
            try
            {
                var buscaContatosModel = new List<ContatoModel>();
                
                var buscaContatosDto = await _contatoApplication.ConsultarTodosContatos();


                foreach (var item in buscaContatosDto)
                {
                    var model = new ContatoModel() 
                    { 
                        IdContato = item.IdContato,
                        Nome = item.Nome,
                        Email = item.Email,
                        DDD = item.DDD,
                        Telefone = item.Telefone    
                    };

                    buscaContatosModel.Add(model);

                }

                return Ok(buscaContatosModel);
            }
            catch (Exception ex)
            {                
                AdicionarErroProcessamento("Erro ao consutlar os contatos");
                AddExptionErrorMessage(ex);
                return CustomResponse();

            }
        }

        [HttpGet("/contatos/{ddd:int}")]
        [ProducesResponseType(typeof(List<ContatoModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ConsultarContatosPorDDD(int ddd)
        {
            try
            {
                var buscaContatosModel = new List<ContatoModel>();

                var buscaContatosDto = await _contatoApplication.ConsultarContatosPorDDD(ddd);

                foreach (var item in buscaContatosDto)
                {
                    var model = new ContatoModel()
                    {
                        IdContato = item.IdContato,
                        Nome = item.Nome,
                        Email = item.Email,
                        DDD = item.DDD,
                        Telefone = item.Telefone
                    };

                    buscaContatosModel.Add(model);

                }

                return Ok(buscaContatosModel);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento("Erro ao consutlar os contatos por DDD");
                AddExptionErrorMessage(ex);
                return CustomResponse();                

            }
        }

        [HttpPost("/contato")]
        [ProducesResponseType(StatusCodes.Status201Created)]        
        public async Task<IActionResult> CadastrarContato(CadastrarAtualizarContatoModel contato)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponse(ModelState);

                var dto = new CadastrarAtualizarContatoDto()
                {
                    Nome = contato.Nome,
                    Email = contato.Email,
                    Telefone = contato.Telefone,
                    DDD = contato.DDD
                };

                await _contatoApplication.CadastrarContato(dto);

                return Created();
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento("Erro ao cadastrar o contato");
                AddExptionErrorMessage(ex);
                return CustomResponse();

            }
        }

        [HttpPut("/contato/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarContato(int id, CadastrarAtualizarContatoModel contato)
        {
            try
            {
                var dto = new CadastrarAtualizarContatoDto()
                {
                    Nome = contato.Nome,
                    Email = contato.Email,
                    Telefone = contato.Telefone,
                    DDD = contato.DDD
                };

                await _contatoApplication.AtualizarContrato(id, dto);

                return NoContent();
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento("Erro ao atualizar o contatos");
                AddExptionErrorMessage(ex);
                return CustomResponse();

            }
        }


        [HttpDelete("/contato/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletarContato(int id)
        {
            try
            {
                await _contatoApplication.DeletarContato(id);
                return Ok();
            }
            catch (Exception ex)
            {

                AdicionarErroProcessamento("Erro ao deletar o contato");
                AddExptionErrorMessage(ex);
                return CustomResponse(); ;
            }
        }

        private void AddExptionErrorMessage(Exception ex)
        {
            if (ex != null && !string.IsNullOrEmpty(ex.Message)) AdicionarErroProcessamento(ex.Message);
        }
    }

}
