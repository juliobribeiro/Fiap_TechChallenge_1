using FIAP._6NETT_GRUPO31.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Application.Tests.Dto
{
    public class ContatoDtoTests
    {
        [Fact]
        public void ContatoDto_Properties_ShouldSetAndGetValuesCorrectly()
        {
            // Arrange
            int expectedId = 1;
            string expectedNome = "João";
            string expectedEmail = "joao@email.com";
            string expectedTelefone = "123456789";
            int expectedDDD = 11;

            // Act
            var contatoDto = new ContatoDto
            {
                IdContato = expectedId,
                Nome = expectedNome,
                Email = expectedEmail,
                Telefone = expectedTelefone,
                DDD = expectedDDD
            };

            // Assert
            Assert.Equal(expectedId, contatoDto.IdContato);
            Assert.Equal(expectedNome, contatoDto.Nome);
            Assert.Equal(expectedEmail, contatoDto.Email);
            Assert.Equal(expectedTelefone, contatoDto.Telefone);
            Assert.Equal(expectedDDD, contatoDto.DDD);
        }

        [Fact]
        public void ContatoDto_DefaultConstructor_ShouldInitializePropertiesWithDefaultValues()
        {
            // Act
            var contatoDto = new ContatoDto();

            // Assert
            Assert.Equal(0, contatoDto.IdContato);  
            Assert.Null(contatoDto.Nome);           
            Assert.Null(contatoDto.Email);
            Assert.Null(contatoDto.Telefone);
            Assert.Equal(0, contatoDto.DDD);        
        }
    }
}
