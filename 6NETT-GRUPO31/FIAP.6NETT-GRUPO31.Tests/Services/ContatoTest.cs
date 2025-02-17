using FIAP._6NETT_GRUPO31.API.Controllers;
using FIAP._6NETT_GRUPO31.API.Model;
using FIAP._6NETT_GRUPO31.Application.Dto;
using FIAP._6NETT_GRUPO31.Application.Interfaces;
using FIAP._6NETT_GRUPO31.Infra.Data.Context;
using FIAP._6NETT_GRUPO31.Tests.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net;
using Xunit.Abstractions;


namespace FIAP._6NETT_GRUPO31.Tests.Services
{
    public class ContatoTest : IntegrationTeste
    {
        private readonly IntegrationTeste _teste;
        private readonly IContatoApplication _contatoApplication;
        private readonly ContatoController _contatoController;
        public ContatoTest(WebApplicationFactory<Program> factory) : base(factory)
        {            
            var scope = _servicesCollection.BuildServiceProvider().CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<FIAPContext>();
            CreateContext(_context);            
        }

        [Fact]
        public async Task ConsultarContatos_ShouldReturnOkResult_WithListOfContatos()
        {
            var response = await Client.GetAsync("/contatos");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            Assert.NotNull(result);

            var contatos = JsonConvert.DeserializeObject<List<ContatoDto>>(result);   

            Assert.True(contatos.Any()); 
        }
    }
}
