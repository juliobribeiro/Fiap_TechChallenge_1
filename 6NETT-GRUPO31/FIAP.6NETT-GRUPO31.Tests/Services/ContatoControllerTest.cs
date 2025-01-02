using FIAP._6NETT_GRUPO31.Application.Interfaces;
using FIAP._6NETT_GRUPO31.Infra.Data.Context;
using FIAP._6NETT_GRUPO31.Service.Controllers;
using FIAP._6NETT_GRUPO31.Service.Model;
using FIAP._6NETT_GRUPO31.Tests.Infra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Tests.Services
{
    [Collection("Test collection")]
    public class ContatoControllerTest
    {
        private readonly TextFixture _textFixture;        
        private readonly IContatoApplication _contatoApplication;
        private readonly ContatoController _contatoController;
        public ContatoControllerTest(TextFixture fixture)
        {
            _textFixture = fixture;

            var scope = _textFixture._servicesCollection.BuildServiceProvider().CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<FIAPContext>();
            _contatoApplication = scope.ServiceProvider.GetRequiredService<IContatoApplication>();
            _contatoController = new ContatoController(_contatoApplication);

            _textFixture.CreateContext(_context);
        }

        [Fact]
        public async Task ConsultarContatos_ShouldReturnOkResult_WithListOfContatos()
        {
            var contatos = await _contatoController.ConsultarContatos();

            var okResult = Assert.IsType<OkObjectResult>(contatos);
            var returnedContatos = Assert.IsType<List<ContatoModel>>(okResult.Value);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(12)]
        public async Task ConsultarContatosPorDDD_ShouldReturnOkResult_WithListOfContatos(int ddd)
        {
            var contatos = await _contatoController.ConsultarContatosPorDDD(ddd);

            var okResult = Assert.IsType<OkObjectResult>(contatos);
            var returnedContatos = Assert.IsType<List<ContatoModel>>(okResult.Value);
        }

        [Fact]
        public async Task CadastrarContato_ShouldReturnCreatedResult_WhenModelIsValid()
        {
            // Arrange
            var contatoModel = new CadastrarAtualizarContatoModel
            {
                Nome = "João",
                Email = "joao@email.com",
                Telefone = "123456789",
                DDD = 11
            };

            var result = await _contatoController.CadastrarContato(contatoModel);            

            // Assert
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task CadastrarContato_ShouldReturnBadRequest_WhenEmailExist()
        {
            // Arrange
            var contatoModel = new CadastrarAtualizarContatoModel
            {
                Nome = "João",
                Email = "rodrigo@email.com",
                Telefone = "123456789",
                DDD = 11
            };

            var result = await _contatoController.CadastrarContato(contatoModel);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            var returnedContatos = Assert.IsType<ValidationProblemDetails>(badRequest.Value);
            Assert.NotNull(returnedContatos.Errors.FirstOrDefault(x => x.Value.Equals("O email rodrigo@email.com já está sendo usando para outro contato")));

        }

      



    }
}
