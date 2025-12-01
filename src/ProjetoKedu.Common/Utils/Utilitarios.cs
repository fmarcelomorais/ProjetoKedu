using ProjetoKedu.Core.Entities;
using ProjetoKedu.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Common.Utils
{
    public static class Utilitarios
    {
        public static Cobranca AjustaStatus(this Cobranca cobranca)
        {
            if (cobranca.StatusCobranca == EStatusCobranca.PAGA || cobranca.StatusCobranca == EStatusCobranca.CANCELADA)
            {
                cobranca.StatusCobranca = cobranca.StatusCobranca;
                return cobranca;
            }                
            cobranca.StatusCobranca = cobranca.Vencimento < DateTime.Now ? EStatusCobranca.VENCIDA : cobranca.StatusCobranca;

            return cobranca; 
        }
    }
}
