using ProjetoKedu.Common.Erros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Common.ValueObjects
{
    public class Nome
    {
        public string Name { get; set; }

        public Nome(string name)
        {
            ValidateName(name);
            if (Error.ListErrors()?.Count > 0) return;
            Name = name;
        }

        private void ValidateName(string name)
        {
            if (name.Length < 3)
                Error.GetError("Nome não pode ter menos de 3 caracteres");
            if (string.IsNullOrEmpty(name))
                Error.GetError("Nome não pode ser vazio");
        }

        
    }
}
