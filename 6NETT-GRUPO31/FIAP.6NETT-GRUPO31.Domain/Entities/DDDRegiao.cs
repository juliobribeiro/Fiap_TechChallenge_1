using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP._6NETT_GRUPO31.Domain.Entities
{
    public class DDDRegiao
    {
        public int IdDDDRegiao { get; set; }
        public string Ddd { get; set; }
        public string Regiao { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public IEnumerable<Contatos> Contatos { get; set; } 

        public DDDRegiao()
        {
                
        }

        public DDDRegiao(int idDDDRegiao, string ddd, string regiao, string cidade, string uF)
        {
            
            IdDDDRegiao = idDDDRegiao;
            Ddd = ddd;
            Regiao = regiao;
            Cidade = cidade;
            UF = uF;    
        }

    }
}
