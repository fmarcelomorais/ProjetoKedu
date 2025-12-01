using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ProjetoKedu.InfraEstrutura.Interfaces;
using System.Data;
using System.Transactions;

namespace ProjetoKedu.InfraEstrutura
{
    public class DbContext : IDbContext
    {
        private string ConnectionString { get; }
        public NpgsqlConnection Connection { get; set; }

        public DbContext(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("ConnectionString");
            Connection = new NpgsqlConnection(ConnectionString);
        }

        public NpgsqlConnection Conexao()
            => new NpgsqlConnection(ConnectionString);
        public async Task<NpgsqlTransaction> Transacao()
        {
            var conexao = Conexao();
            await conexao.OpenAsync();
   
            return await conexao.BeginTransactionAsync();
        }

        public async Task<bool> Salvar(string sql, object parametros, NpgsqlTransaction transacao = null)
        {
           
            var linhas = 0;
            try
            {
                if(transacao == null)
                {
                    using var conexao = Conexao();
                    await conexao.OpenAsync();
                    linhas = await conexao.ExecuteAsync(sql, parametros);
                    return linhas > 0;
                }
                else
                {
                    linhas = await Connection.ExecuteAsync(sql, parametros, transacao);
                    return linhas > 0;

                }

            }
            catch(Exception ex)
            {
                await transacao.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }
       
        public async Task<IEnumerable<T>> Buscar<T>(string sql, object parametros = null)
        {
            using var conexao = Conexao();
           await conexao.OpenAsync();

            var retorno = await conexao.QueryAsync<T>(sql, parametros);
            if(retorno.Any())
                return retorno;
            return null;
        }
        
    }
}
