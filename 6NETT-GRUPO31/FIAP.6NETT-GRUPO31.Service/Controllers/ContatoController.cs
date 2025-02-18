using FIAP._6NETT_GRUPO31.Application.Dto;
using FIAP._6NETT_GRUPO31.Application.Interfaces;
using FIAP._6NETT_GRUPO31.API.Model;
using Microsoft.AspNetCore.Mvc;
using Contact.WebApi.Core.Controllers;

namespace FIAP._6NETT_GRUPO31.API.Controllers
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
    }

}
