using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Application.DTOs
{
    public class RetornoPadraoDto<T>
    {
        public int StatusCode { get; set; }
        public string Mensagem { get; set; }
        public IEnumerable<T>? Retorno { get; set; }
    };
   
}
