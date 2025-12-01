using Dapper;
using ProjetoKedu.Common.Erros;
using ProjetoKedu.Core.Entities;
using ProjetoKedu.Core.Interfaces;
using ProjetoKedu.InfraEstrutura.Interfaces;
using ProjetoKedu.Common.Utils;

namespace ProjetoKedu.InfraEstrutura.Repositories
{
    public class ResponsavelFinanceiroRep : IResponsavelFinanceiroRep
    {
        private readonly IDbContext Context;
        public ResponsavelFinanceiroRep(IDbContext context)
        {
            Context = context;
        }
        public async Task<bool> Cadastrar(ResponsavelFinanceiro responsavel)
        {
            var sql = @"INSERT INTO responsaveis (id, nome) VALUES (@Id, @Nome);";
            var gravado = await Context.Salvar(sql, new {Id = responsavel.Id, Nome = responsavel.Nome});
            
            if (!gravado)
            {
                Error.GetError("Não foi possivel gravar o Responsavel");
                return false;
            }
            return true;
        }
                       
        // Regras
        public async Task<IEnumerable<PlanoDePagamento>> RetornaPlanos(Guid id)
        {          
            var conexao = Context.Conexao();
            await conexao.OpenAsync();

            var sql = @"SELECT 
                        p.id as planoId, p.*, 
                        r.id as responsavelId, r.*,
                        ct.id as centroId, ct.*, 
                        c.id as cobrancaId, c.valor, c.vencimento, c.formapagamento, status AS StatusCobranca, codigopagamento
                        FROM planopagamento as p 
                        JOIN centrodecusto ct ON p.""centrodecustoId"" = ct.id
                        JOIN cobrancas as c ON c.""planopagamentoId"" = p.id
                        JOIN responsaveis as r ON p.""responsavelId"" = r.id
                        WHERE r.id = @Id;";
            
            var planosPagamentos = new List<PlanoDePagamento>();

            await conexao.QueryAsync<PlanoDePagamento, ResponsavelFinanceiro, CentroDeCusto, Cobranca, PlanoDePagamento>(sql,
                 (plano, responsavel, centro, cobranca) =>
                 {
                     if (planosPagamentos.SingleOrDefault(p => p.Id == plano.Id) == null)
                     {
                         plano.Responsavel = responsavel;
                         plano.CentroCusto = centro;
                         plano.Cobrancas = new List<Cobranca>();

                         planosPagamentos.Add(plano);
                     }
                     else
                     {
                         plano = planosPagamentos.SingleOrDefault(p => p.Id == plano.Id);
                     }
                     cobranca.AjustaStatus();
                     plano.Cobrancas.Add(cobranca);
                     plano.ValorTotalPlano = plano.Cobrancas.Sum(c => c.Valor);

                     return plano;
                 },
                 new { Id = id },
                 splitOn: "planoId,responsavelId,centroId,cobrancaId");

            return planosPagamentos;
        }

        
    }
}
