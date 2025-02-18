using Contact.Core.Dto;
using FIAP._6NETT_GRUPO31.Application.Dto;
using FIAP._6NETT_GRUPO31.Application.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Application.Tests.Interfaces
{
    public class IContratoApplicationTests
    {
        private readonly Mock<IContatoApplication> _mockContatoApp;

        public IContratoApplicationTests()
        {
            _mockContatoApp = new Mock<IContatoApplication>();
        }

        [Fact]
        public async Task CadastrarContato_ShouldReturnTrue_WhenContatoIsSuccessfullyCreated()
        {
            // Arrange
            var dto = new CadastrarAtualizarContatoDto
            {
                Nome = "João",
                Email = "joao@email.com",
                Telefone = "123456789",
                DDD = 11
            };
            _mockContatoApp.Setup(app => app.CadastrarContato(dto)).ReturnsAsync(true);

            // Act
            var result = await _mockContatoApp.Object.CadastrarContato(dto);

            // Assert
            Assert.True(result);
            _mockContatoApp.Verify(app => app.CadastrarContato(dto), Times.Once);
        }

        [Fact]
        public async Task AtualizarContato_ShouldReturnTrue_WhenContatoIsSuccessfullyUpdated()
        {
            // Arrange
            int contatoId = 1;
            var dto = new CadastrarAtualizarContatoDto
            {
                Nome = "João Atualizado",
                Email = "joaoatualizado@email.com",
                Telefone = "987654321",
                DDD = 11
            };
            _mockContatoApp.Setup(app => app.AtualizarContrato(contatoId, dto)).ReturnsAsync(true);

            // Act
            var result = await _mockContatoApp.Object.AtualizarContrato(contatoId, dto);

            // Assert
            Assert.True(result);
            _mockContatoApp.Verify(app => app.AtualizarContrato(contatoId, dto), Times.Once);
        }

        [Fact]
        public async Task ConsultarContatosPorDDD_ShouldReturnListOfContatos_WhenDDDIsProvided()
        {
            // Arrange
            int ddd = 11;
            var expectedContatos = new List<ContatoDto>
        {
            new ContatoDto { IdContato = 1, Nome = "João", Email = "joao@email.com", Telefone = "123456789", DDD = 11 },
            new ContatoDto { IdContato = 2, Nome = "Maria", Email = "maria@email.com", Telefone = "987654321", DDD = 11 }
        };
            _mockContatoApp.Setup(app => app.ConsultarContatosPorDDD(ddd)).ReturnsAsync(expectedContatos);

            // Act
            var result = await _mockContatoApp.Object.ConsultarContatosPorDDD(ddd);

            // Assert
            Assert.Equal(expectedContatos.Count, result.Count);
            Assert.Equal(expectedContatos, result);
            _mockContatoApp.Verify(app => app.ConsultarContatosPorDDD(ddd), Times.Once);
        }

        [Fact]
        public async Task ConsultarTodosContatos_ShouldReturnListOfAllContatos()
        {
            // Arrange
            var expectedContatos = new List<ContatoDto>
        {
            new ContatoDto { IdContato = 1, Nome = "João", Email = "joao@email.com", Telefone = "123456789", DDD = 11 },
            new ContatoDto { IdContato = 2, Nome = "Maria", Email = "maria@email.com", Telefone = "987654321", DDD = 11 }
        };
            _mockContatoApp.Setup(app => app.ConsultarTodosContatos()).ReturnsAsync(expectedContatos);

            // Act
            var result = await _mockContatoApp.Object.ConsultarTodosContatos();

            // Assert
            Assert.Equal(expectedContatos.Count, result.Count);
            Assert.Equal(expectedContatos, result);
            _mockContatoApp.Verify(app => app.ConsultarTodosContatos(), Times.Once);
        }

        [Fact]
        public async Task DeletarContato_ShouldReturnTrue_WhenContatoIsSuccessfullyDeleted()
        {
            // Arrange
            int contatoId = 1;
            _mockContatoApp.Setup(app => app.DeletarContato(contatoId)).ReturnsAsync(true);

            // Act
            var result = await _mockContatoApp.Object.DeletarContato(contatoId);

            // Assert
            Assert.True(result);
            _mockContatoApp.Verify(app => app.DeletarContato(contatoId), Times.Once);
        }
    }
}
