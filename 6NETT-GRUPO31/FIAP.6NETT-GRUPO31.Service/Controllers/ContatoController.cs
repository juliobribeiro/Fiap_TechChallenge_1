using Microsoft.AspNetCore.Mvc;

namespace FIAP._6NETT_GRUPO31.Service.Controllers
{    

    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> ConsultarContatos(string ddd)
        {
            try
            {

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao consutlar os contatos");
                
            }
        }
    }

}
