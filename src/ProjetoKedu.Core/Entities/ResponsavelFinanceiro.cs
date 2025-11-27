using ProjetoKedu.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Core.Entities
{
    public class ResponsavelFinanceiro : Entity
    {
        public string Nome { get; set; }
        public ResponsavelFinanceiro(string nomeResponsavel)
        {
            Nome = nomeResponsavel;
        }

        public ResponsavelFinanceiro()
        {
            
        }

        public string NomeResponsavel()
            => Nome;
    }
}
