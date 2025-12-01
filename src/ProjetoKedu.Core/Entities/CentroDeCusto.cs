using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Core.Entities
{
    public  class CentroDeCusto : Entity
    {
        public int Codigo {  get; set; }
        public string Tipo { get; set; }

        public CentroDeCusto(Guid id, int codigo, string tipo)
        {
            Id = id;
            Codigo = codigo;    
            Tipo = tipo;
        }

        public CentroDeCusto()
        {
            
        }
    }
}
