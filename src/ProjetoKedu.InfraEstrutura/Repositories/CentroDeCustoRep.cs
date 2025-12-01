using ProjetoKedu.Common.Erros;
using ProjetoKedu.Core.Entities;
using ProjetoKedu.Core.Interfaces;
using ProjetoKedu.InfraEstrutura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoKedu.InfraEstrutura.Repositories
{
    public class CentroDeCustoRep : ICentroDeCustoRep
    {
        private readonly IDbContext Context;
        public CentroDeCustoRep(IDbContext context)
        {
            Context = context;   
        }
        public async Task<bool> Cadastrar(CentroDeCusto centroDeCusto)
        {
            var sql = @"INSERT INTO centrodecusto (id, codigo, tipo) VALUES (@Id, @Codigo, @Tipo);";
            var gravado = await Context.Salvar(sql, new { Id = centroDeCusto.Id, Codigo = centroDeCusto.Codigo, Tipo = centroDeCusto.Tipo });

            if (!gravado)
            {
                Error.GetError("Não foi possivel gravar o Centro de Custo");
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<CentroDeCusto>> RetornaCentroDeCusto()
        {
            var sql = @"SELECT id, codigo, tipo FROM centrodecusto;";
            var centros = await Context.Buscar<CentroDeCusto>(sql);

            return centros;
        }

        public async Task<CentroDeCusto> RetornaCentroDeCustoPorCodigo(int codigo)
        {
            var sql = @"SELECT id, codigo, tipo FROM centrodecusto WHERE Codigo = @Codigo;";
            var centro = await Context.Buscar<CentroDeCusto>(sql, new {Codigo = codigo });

            return centro.FirstOrDefault();
        }
    }
}
