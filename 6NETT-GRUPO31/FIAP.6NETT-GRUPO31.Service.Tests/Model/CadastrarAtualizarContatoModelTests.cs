using FIAP._6NETT_GRUPO31.Service.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Service.Tests.Model
{
    public class CadastrarAtualizarContatoModelTests
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
        public void CadastrarAtualizarContatoModel_ShouldPassValidation_WhenAllPropertiesAreValid()
        {
            // Arrange
            var model = new CadastrarAtualizarContatoModel
            {
                Nome = "João",
                Email = "joao@email.com",
                Telefone = "123456789",
                DDD = 11
            };

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            Assert.Empty(validationResults); 
        }

        [Fact]
        public void CadastrarAtualizarContatoModel_ShouldFailValidation_WhenNomeIsMissing()
        {
            // Arrange
            var model = new CadastrarAtualizarContatoModel
            {
                Email = "joao@email.com",
                Telefone = "123456789",
                DDD = 11
            };

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            Assert.Single(validationResults); 
            Assert.Equal("O campo nome é obrigatório", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void CadastrarAtualizarContatoModel_ShouldFailValidation_WhenEmailIsInvalid()
        {
            // Arrange
            var model = new CadastrarAtualizarContatoModel
            {
                Nome = "João",
                Email = "emailinvalido", 
                Telefone = "123456789",
                DDD = 11
            };

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            Assert.Single(validationResults); 
            Assert.Equal("E-mail inválido", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void CadastrarAtualizarContatoModel_ShouldFailValidation_WhenTelefoneExceedsMaxLength()
        {
            // Arrange
            var model = new CadastrarAtualizarContatoModel
            {
                Nome = "João",
                Email = "joao@email.com",
                Telefone = "1234567890", 
                DDD = 11
            };

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            Assert.Single(validationResults); 
            Assert.Equal("O campo telefone pode ter no máximo 9 caracteres", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void CadastrarAtualizarContatoModel_ShouldFailValidation_WhenDDDIsOutOfRange()
        {
            // Arrange
            var model = new CadastrarAtualizarContatoModel
            {
                Nome = "João",
                Email = "joao@email.com",
                Telefone = "123456789",
                DDD = 100 
            };

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            Assert.Single(validationResults); 
            Assert.Equal("O DDD precisa estar entre 0 e 99", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void CadastrarAtualizarContatoModel_ShouldFailValidation_WhenTelefoneIsMissing()
        {
            // Arrange
            var model = new CadastrarAtualizarContatoModel
            {
                Nome = "João",
                Email = "joao@email.com",
                DDD = 11
            };

            // Act
            var validationResults = ValidateModel(model);

            // Assert
            Assert.Single(validationResults); 
            Assert.Equal("O campo telefone é obrigatório", validationResults[0].ErrorMessage);
        }

        
    }
}
