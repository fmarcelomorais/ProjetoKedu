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
        private Nome Nome { get; set; }
        public ResponsavelFinanceiro(string nomeResponsavel)
        {
            Nome = new Nome(nomeResponsavel);
        }

        public string NomeResponsavel()
            => Nome.Name;
    }
}
