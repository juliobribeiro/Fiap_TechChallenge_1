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
                AddExptionErrorMessage(ex);
                return CustomResponse();

            }
        }

        [HttpGet("/contatos/{ddd:int}")]
        [ProducesResponseType(typeof(List<ContatoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ConsultarContatosPorDDD(int ddd)
        {
            try
            {            
                var buscaContatos = await _contatoApplication.ConsultarContatosPorDDD(ddd);

                return Ok(buscaContatos);
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
        public async Task<IActionResult> CadastrarContato(CadastrarAtualizarContatoDto contato)
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
                AddExptionErrorMessage(ex);
                return CustomResponse();

            }
        }

        [HttpPut("/contato/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarContato(int id, CadastrarAtualizarContatoDto contato)
        {
            try
            {
                await _contatoApplication.AtualizarContrato(id,contato);

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
