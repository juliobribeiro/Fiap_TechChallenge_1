using FIAP._6NETT_GRUPO31.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Domain.Tests.Entities
{
    public class ContatosTests
    {
        [Fact]
        public void DevoCriarClasseContatosCom_IdContato_Nome_Email_Telefone_DDDRegiao_Corretamente()
        {
            // Arrange
            int idContato = 1;
            string nome = "Nome Xpto";
            string email = "nome.xpto@teste.com";
            string telefone = "21999999999";

            DDDRegiao dDDRegiao = new DDDRegiao(1, "21", "Sudeste", "Rio Bonito", "RJ");

            // Act
            Contatos contato = new Contatos(idContato, nome, email, telefone, dDDRegiao);

            // Assert
            Assert.Equal(idContato, contato.IdContato);
            Assert.Equal(nome, contato.Nome);
            Assert.Equal(email, contato.Email);
            Assert.Equal(telefone, contato.Telefone);
            Assert.Equal(dDDRegiao, contato.DDDRegiao);
        }

    }
}
