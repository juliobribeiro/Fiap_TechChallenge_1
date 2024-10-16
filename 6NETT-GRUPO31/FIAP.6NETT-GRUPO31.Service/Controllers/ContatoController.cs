using FIAP._6NETT_GRUPO31.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FIAP._6NETT_GRUPO31.Service.Controllers
{    

    
    [ApiController]
    public class ContatoController : MainController
    {

        [HttpGet("/contatos")]
        [ProducesResponseType(typeof(List<ContatoDto>), StatusCodes.Status200OK)]        
        public async Task<IActionResult> ConsultarContatos()
        {
            try
            {

                return Ok();
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

                return CustomResponse();
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
                
                return CustomResponse();
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

                return CustomResponse();
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento("Erro ao atualizar o contatos");
                return CustomResponse();

            }
        }
    }

}
