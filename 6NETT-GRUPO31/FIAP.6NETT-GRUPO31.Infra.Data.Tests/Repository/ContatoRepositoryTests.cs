using FIAP._6NETT_GRUPO31.Domain.Entities;
using FIAP._6NETT_GRUPO31.Infra.Data.Context;
using FIAP._6NETT_GRUPO31.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FIAP._6NETT_GRUPO31.Infra.Data.Tests.Repository
{
    public class ContatoRepositoryTests
    {
        private FIAPContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<FIAPContext>()
                .UseInMemoryDatabase(databaseName: "FIAP_6NETTT")
                .Options;

            return new FIAPContext(options);
        }

        [Fact]
        public async Task AdicionaContato_DeveRetornarTrue_QuandoContatoAdicionadoComSucesso()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var repository = new ContatoRepository(context);
            var contato = new Contatos { IdContato = 1, Nome = "Teste", DDD = 11, Telefone = "123456789", Email = "teste@teste.com" };

            // Act
            var resultado = await repository.AdicionaContato(contato);

            // Assert
            Assert.True(resultado);
            Assert.Equal(1, context.Contatos.Count());
        }

        [Fact]
        public async Task ConsultaContatos_DeveRetornarContatos_QuandoDDDInformado()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var repository = new ContatoRepository(context);
            context.Contatos.AddRange(
                new Contatos { Nome = "Contato1", DDD = 11, Telefone = "123456789", Email = "contato1@teste.com" },
                new Contatos { Nome = "Contato2", DDD = 21, Telefone = "987654321", Email = "contato2@teste.com" }
            );
            await context.SaveChangesAsync();

            // Act
            var contatos = await repository.ConsultaContatos(11);

            // Assert
            Assert.Single(contatos);
            Assert.Equal(11, contatos.First().DDD);
        }

        [Fact]
        public async Task ConsultarContatoPorId_DeveRetornarContato_QuandoIdExistir()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var repository = new ContatoRepository(context);
            var contato = new Contatos { Nome = "Teste", DDD = 11, Telefone = "123456789", Email = "teste@teste.com" };
            context.Contatos.Add(contato);
            await context.SaveChangesAsync();

            // Act
            var resultado = await repository.ConsultarContatoPorId(1);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("Teste", resultado.Nome);
        }

        [Fact]
        public async Task DeletarContato_DeveRetornarTrue_QuandoContatoRemovido()
        {
            // Arrange
            var context = CreateInMemoryContext();
            var repository = new ContatoRepository(context);
            var contato = new Contatos { Nome = "Teste", DDD = 11, Telefone = "123456789", Email = "teste@teste.com" };
            context.Contatos.Add(contato);
            await context.SaveChangesAsync();

            // Act
            var resultado = await repository.DeletarContato(contato);

            // Assert
            Assert.True(resultado);
            Assert.Empty(context.Contatos);
        }
    }
}
