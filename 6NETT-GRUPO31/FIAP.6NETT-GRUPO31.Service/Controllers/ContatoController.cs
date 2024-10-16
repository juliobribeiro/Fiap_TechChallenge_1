using FIAP._6NETT_GRUPO31.Application.Dto;
using FIAP._6NETT_GRUPO31.Application.Interfaces;
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
        [ProducesResponseType(typeof(List<ContatoDto>), StatusCodes.Status200OK)]        
        public async Task<IActionResult> ConsultarContatos()
        {
            try
            {
                var buscaContatos = await _contatoApplication.ConsultarTodosContatos();

                return Ok(buscaContatos);
            }
            catch (Exception ex)
            {                
                AdicionarErroProcessamento("Erro ao consutlar os contatos");
                return CustomResponse();

            }
        }

        [HttpGet("/contatos/{ddd}")]
        [ProducesResponseType(typeof(List<ContatoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ConsultarContatosPorDDD(string ddd)
        {
            try
            {
                var buscaContatos = await _contatoApplication.ConsultarContatosPorDDD(ddd);

                return Ok(buscaContatos);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento("Erro ao consutlar os contatos por DDD");
                return CustomResponse();                

            }
        }

        [HttpPost("/contato")]
        [ProducesResponseType(StatusCodes.Status201Created)]        
        public async Task<IActionResult> CadastrarContato(CadastrarContatoDto contato)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponse(ModelState);

                await _contatoApplication.CadastrarContato(contato);

                return Created();
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento("Erro ao cadastrar o contato");
                return CustomResponse();

            }
        }

        [HttpPut("/contato/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarContato(CadastrarContatoDto contato)
        {
            try
            {
                await _contatoApplication.AtualizarContrato(contato);

                return NoContent();
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento("Erro ao atualizar o contatos");
                return CustomResponse();

            }
        }
    }

}
