using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Core.Entities
{
    public  class CentroDeCusto : Entity
    {
        private int Codigo {  get; set; }
        private string Tipo { get; set; }

        public CentroDeCusto(int codigo, string tipo)
        {
            Codigo = codigo;    
            Tipo = tipo;
        }

        public int RetornaCodigo()
            => Codigo;
        public string RetornaTipo()
            => Tipo;
    }
}
