using FIAP._6NETT_GRUPO31.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Domain.Tests.Entities
{
    public class DDDRegiaoTests
    {
        [Fact]
        public void DevoCriarClasseDDDRegiaoCom_Id_DDD_Regiao_Cidade_UF_Corretamente()
        {
            // Arrange
            int id = 1;
            string dDD = "21";
            string regiao = "Sudeste";
            string cidade = "Rio Bonito";
            string uF = "RJ";

            // Act
            DDDRegiao dddRegiao = new DDDRegiao(id, dDD, regiao, cidade, uF);

            // Assert
            Assert.Equal(id, dddRegiao.IdDDDRegiao);
            Assert.Equal(dDD, dddRegiao.Ddd);
            Assert.Equal(regiao, dddRegiao.Regiao);
            Assert.Equal(cidade, dddRegiao.Cidade);
            Assert.Equal(uF, dddRegiao.UF);
        }
    }
}
