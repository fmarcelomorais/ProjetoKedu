using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Common.Erros
{
    public static class Error
    {
        private static List<string> ErrorsMessages { get; set; } = new List<string>();

        public static void GetError(string error)
        {
            ErrorsMessages.Add(error);
        }

        public static List<string> ListErrors()
            => ErrorsMessages; 
        
    }
}
