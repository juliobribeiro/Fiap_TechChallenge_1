using FIAP._6NETT_GRUPO31.Application.Dto;
using FIAP._6NETT_GRUPO31.Application.Interfaces;
using FIAP._6NETT_GRUPO31.API.Controllers;
using FIAP._6NETT_GRUPO31.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.API.Tests.Controllers
{
    public class ContatoControllerTests
    {
        private readonly Mock<IContatoApplication> _contatoApplicationMock;
        private readonly ContatoController _controller;

        public ContatoControllerTests()
        {
            _contatoApplicationMock = new Mock<IContatoApplication>();
            _controller = new ContatoController(_contatoApplicationMock.Object);
        }

        //[Fact]
        //public async Task ConsultarContatos_ShouldReturnOkResult_WithListOfContatos()
        //{
        //    // Arrange
        //    var contatosDto = new List<ContatoDto>
        //{
        //    new ContatoDto { IdContato = 1, Nome = "João", Email = "joao@email.com", Telefone = "123456789", DDD = 11 },
        //    new ContatoDto { IdContato = 2, Nome = "Maria", Email = "maria@email.com", Telefone = "987654321", DDD = 22 }
        //};

        //    _contatoApplicationMock.Setup(x => x.ConsultarTodosContatos()).ReturnsAsync(contatosDto);

        //    // Act
        //    var result = await _controller.ConsultarContatos();

        //    // Assert
        //    var okResult = Assert.IsType<OkObjectResult>(result);
        //    var returnedContatos = Assert.IsType<List<ContatoModel>>(okResult.Value);
        //    Assert.Equal(2, returnedContatos.Count);
        //}

        //[Fact]
        //public async Task ConsultarContatosPorDDD_ShouldReturnOkResult_WithListOfContatos()
        //{
        //    // Arrange
        //    var ddd = 11;
        //    var contatosDto = new List<ContatoDto>
        //{
        //    new ContatoDto { IdContato = 1, Nome = "João", Email = "joao@email.com", Telefone = "123456789", DDD = ddd }
        //};

        //    _contatoApplicationMock.Setup(x => x.ConsultarContatosPorDDD(ddd)).ReturnsAsync(contatosDto);

        //    // Act
        //    var result = await _controller.ConsultarContatosPorDDD(ddd);

        //    // Assert
        //    var okResult = Assert.IsType<OkObjectResult>(result);
        //    var returnedContatos = Assert.IsType<List<ContatoModel>>(okResult.Value);
        //    Assert.Single(returnedContatos);
        //    Assert.Equal(ddd, returnedContatos[0].DDD);
        //}

        //[Fact]
        //public async Task CadastrarContato_ShouldReturnCreatedResult_WhenModelIsValid()
        //{
        //    // Arrange
        //    var contatoModel = new CadastrarAtualizarContatoModel
        //    {
        //        Nome = "João",
        //        Email = "joao@email.com",
        //        Telefone = "123456789",
        //        DDD = 11
        //    };

        //    _contatoApplicationMock.Setup(x => x.CadastrarContato(It.IsAny<CadastrarAtualizarContatoDto>())).ReturnsAsync(true);

        //    // Act
        //    var result = await _controller.CadastrarContato(contatoModel);

        //    // Assert
        //    Assert.IsType<CreatedResult>(result);
        //}

        //[Fact]
        //public async Task AtualizarContato_ShouldReturnNoContentResult_WhenModelIsValid()
        //{
        //    // Arrange
        //    var id = 1;
        //    var contatoModel = new CadastrarAtualizarContatoModel
        //    {
        //        Nome = "João",
        //        Email = "joao@email.com",
        //        Telefone = "123456789",
        //        DDD = 11
        //    };

        //    _contatoApplicationMock.Setup(x => x.AtualizarContrato(id, It.IsAny<CadastrarAtualizarContatoDto>())).ReturnsAsync(true);

        //    // Act
        //    var result = await _controller.AtualizarContato(id, contatoModel);

        //    // Assert
        //    Assert.IsType<NoContentResult>(result);
        //}

        //[Fact]
        //public async Task DeletarContato_ShouldReturnNoContentResult_WhenDeletionIsSuccessful()
        //{
        //    // Arrange
        //    var id = 1;
        //    _contatoApplicationMock.Setup(x => x.DeletarContato(id)).ReturnsAsync(true);

        //    // Act
        //    var result = await _controller.DeletarContato(id);

        //    // Assert
        //    Assert.IsType<NoContentResult>(result);
        //}

       
    }
}
