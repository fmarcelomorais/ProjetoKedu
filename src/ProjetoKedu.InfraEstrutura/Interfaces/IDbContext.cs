using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.InfraEstrutura.Interfaces
{
    public interface IDbContext
    {
        NpgsqlConnection Conexao();
        Task<NpgsqlTransaction> Transacao();
        Task<bool> Salvar(string sql, object parametros, NpgsqlTransaction useTransaction = null);
        Task<IEnumerable<T>> Buscar<T>(string sql, object parametros = null);
    }
}
