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
        public ResponsavelFinanceiro(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public ResponsavelFinanceiro()
        {

        }

    }
}
