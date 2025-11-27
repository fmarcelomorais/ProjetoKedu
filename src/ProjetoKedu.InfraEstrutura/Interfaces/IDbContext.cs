using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.InfraEstrutura.Interfaces
{
    public interface IDbContext
    {
        Task<bool> Salvar(string sql, object parametros);
        Task<IEnumerable<T>> Buscar<T>(string sql, object parametros = null);
        Task<int> ExecutarComando(string sql, object value);
    }
}
