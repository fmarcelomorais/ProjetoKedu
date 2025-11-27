using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ProjetoKedu.InfraEstrutura.Interfaces;
using System.Data;

namespace ProjetoKedu.InfraEstrutura
{
    public class DbContext : IDbContext
    {
        private string ConnectionString { get; }
        private IDbConnection Connection {  get; set; }
        public DbContext(IConfiguration configuration)
        {
            ConnectionString = configuration?.GetConnectionString("ConnectionString");
            Connection = new NpgsqlConnection(ConnectionString);
        }

        public async Task<bool> Salvar(string sql, object parametros)
        {
            using var conexao = Connection;
            conexao.Open();

            var linhas = await conexao.ExecuteAsync(sql, parametros);
            if (linhas > 0)
                return true;
            return false;
        }

        public async Task<IEnumerable<T>> Buscar<T>(string sql, object parametros = null)
        {
            using var conexao = Connection;
            conexao.Open();

            var retorno = await conexao.QueryAsync<T>(sql, parametros);
            if(retorno.Any())
                return retorno;
            return null;
        }

        public Task<int> ExecutarComando(string sql, object value)
        {
            throw new NotImplementedException();
        }
    }
}
