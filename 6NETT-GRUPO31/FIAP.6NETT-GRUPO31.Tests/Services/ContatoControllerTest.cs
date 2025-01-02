using FIAP._6NETT_GRUPO31.Application.Interfaces;
using FIAP._6NETT_GRUPO31.Infra.Data.Context;
using FIAP._6NETT_GRUPO31.Service.Controllers;
using FIAP._6NETT_GRUPO31.Service.Model;
using FIAP._6NETT_GRUPO31.Tests.Infra;
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
        private readonly FIAPContext _context;
        private readonly IContatoApplication _contatoApplication;
        private readonly ContatoController _contatoController;
        public ContatoControllerTest(TextFixture fixture)
        {
            _textFixture = fixture;

            var scope = _textFixture._servicesCollection.BuildServiceProvider().CreateScope();
            _context = scope.ServiceProvider.GetRequiredService<FIAPContext>();
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



    }
}
