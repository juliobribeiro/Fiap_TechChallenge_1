using FIAP._6NETT_GRUPO31.Application.Dto;
using FIAP._6NETT_GRUPO31.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FIAP._6NETT_GRUPO31.Service.Controllers
{
    [ApiController]
    public class RegiaoController : MainController
    {
        private readonly IRegiaoApplication _regiaoApplication;

        public RegiaoController(IRegiaoApplication regiaoApplication)
        {
            _regiaoApplication = regiaoApplication;
        }

        [HttpGet("/regioes")]
        [ProducesResponseType(typeof(List<DDDRegiaoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultarRegioes()
        {
            try
            {
                var regioes = await _regiaoApplication.GetRegioes();

                return Ok(regioes);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento("Erro ao consutlar as regiões");
                return CustomResponse();

            }
        }        
    }
}
