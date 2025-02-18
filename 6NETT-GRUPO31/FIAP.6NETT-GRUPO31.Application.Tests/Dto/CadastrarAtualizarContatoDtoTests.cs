using Contact.Core.Dto;
using FIAP._6NETT_GRUPO31.Application.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Application.Tests.Dto
{
    public class CadastrarAtualizarContatoDtoTests
    {
        private ValidationContext CreateValidationContext(object model)
        {
            return new ValidationContext(model, null, null);
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, CreateValidationContext(model), validationResults, true);
            return validationResults;
        }

        [Fact]
        public void CadastrarAtualizarContatoDto_ShouldPassValidation_WhenAllPropertiesAreValid()
        {
            // Arrange
            var dto = new CadastrarAtualizarContatoDto
            {
                Nome = "João",
                Email = "joao@email.com",
                Telefone = "123456789",
                DDD = 11
            };

            // Act
            var validationResults = ValidateModel(dto);

            // Assert
            Assert.Empty(validationResults);  
        }

        [Fact]
        public void CadastrarAtualizarContatoDto_ShouldFailValidation_WhenNomeIsMissing()
        {
            // Arrange
            var dto = new CadastrarAtualizarContatoDto
            {
                Email = "joao@email.com",
                Telefone = "123456789",
                DDD = 11
            };

            // Act
            var validationResults = ValidateModel(dto);

            // Assert
            Assert.Single(validationResults); 
            Assert.Equal("O campo nome é obrigatório", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void CadastrarAtualizarContatoDto_ShouldFailValidation_WhenEmailIsInvalid()
        {
            // Arrange
            var dto = new CadastrarAtualizarContatoDto
            {
                Nome = "João",
                Email = "emailinvalido",  
                Telefone = "123456789",
                DDD = 11
            };

            // Act
            var validationResults = ValidateModel(dto);

            // Assert
            Assert.Single(validationResults); 
            Assert.Equal("E-mail inválido", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void CadastrarAtualizarContatoDto_ShouldFailValidation_WhenTelefoneExceedsMaxLength()
        {
            // Arrange
            var dto = new CadastrarAtualizarContatoDto
            {
                Nome = "João",
                Email = "joao@email.com",
                Telefone = "1234567890", 
                DDD = 11
            };

            // Act
            var validationResults = ValidateModel(dto);

            // Assert
            Assert.Single(validationResults); 
            Assert.Equal("O campo telefone pode ter no máximo 9 caracteres", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void CadastrarAtualizarContatoDto_ShouldFailValidation_WhenDDDIsOutOfRange()
        {
            // Arrange
            var dto = new CadastrarAtualizarContatoDto
            {
                Nome = "João",
                Email = "joao@email.com",
                Telefone = "123456789",
                DDD = 100 
            };

            // Act
            var validationResults = ValidateModel(dto);

            // Assert
            Assert.Single(validationResults); 
            Assert.Equal("O DDD precisa estar entre 0 e 99", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void CadastrarAtualizarContatoDto_ShouldFailValidation_WhenTelefoneIsMissing()
        {
            // Arrange
            var dto = new CadastrarAtualizarContatoDto
            {
                Nome = "João",
                Email = "joao@email.com",
                DDD = 11
            };

            // Act
            var validationResults = ValidateModel(dto);

            // Assert
            Assert.Single(validationResults); 
            Assert.Equal("O campo telefone é obrigatório", validationResults[0].ErrorMessage);
        }

    }
}
