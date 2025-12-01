using Dapper;
using ProjetoKedu.Common.Utils;
using ProjetoKedu.Core.Entities;
using ProjetoKedu.Core.Enums;
using ProjetoKedu.Core.Interfaces;
using ProjetoKedu.InfraEstrutura.Interfaces;

namespace ProjetoKedu.InfraEstrutura.Repositories
{
    public class PlanoPagamentoRep : IPlanoPagamentoRep
    {
        private readonly IDbContext Context; 
        public PlanoPagamentoRep(IDbContext context)
        {
            Context = context;
        }
        public async Task<Guid> CadastrarPlano(PlanoDePagamento planoPagamento)
        {
            var transacao = await Context.Transacao();
            var sql = @"INSERT INTO planopagamento VALUES (@Id, @ResponsavelId, @CentroCustoId);";
            var cadastrado = await Context.Salvar(sql, new { planoPagamento.Id, ResponsavelId = planoPagamento.Responsavel.Id, CentroCustoId = planoPagamento.CentroCusto.Id}, transacao);

            if(cadastrado)
            {

                foreach(var cobranca in planoPagamento.Cobrancas)
                {
                    var sqlInsertCobranca = @"INSERT INTO cobrancas
                                             VALUES 
                                            (@Id, @Valor, @Vencimento, @FormaPagamento, @Status, @CodigoPagamento, @IdPlanoPagamento);";

                    cadastrado = await Context.Salvar(sqlInsertCobranca, new
                    {
                        cobranca.Id,
                        cobranca.Valor,
                        Vencimento = cobranca.Vencimento,
                        FormaPagamento = cobranca.MetodoPagamento.ToString(),
                        Status = cobranca.StatusCobranca.ToString(),
                        cobranca.CodigoPagamento,
                        IdPlanoPagamento = planoPagamento.Id
                    }, transacao);
                }
                
               await transacao.CommitAsync();
            }

            return planoPagamento.Id;
        }

        public async Task<PlanoDePagamento> ConsultarPlanoPorId(Guid id)
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
                        WHERE p.id = @Id;";

            var planoPagamento = new PlanoDePagamento();
            var cobrancas = new List<Cobranca>();

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
                new {Id = id },
                splitOn: "planoId,responsavelId,centroId,cobrancaId");

            return planosPagamentos.SingleOrDefault();
        }

        public async Task<IEnumerable<PlanoDePagamento>> ConsultarPlanos()
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
                        JOIN responsaveis as r ON p.""responsavelId"" = r.id;";

            var planosPagamentos = new List<PlanoDePagamento>();
            var cobrancas = new List<Cobranca>();

            var x = await conexao.QueryAsync<PlanoDePagamento, ResponsavelFinanceiro, CentroDeCusto, Cobranca, PlanoDePagamento>(sql,
                (plano, responsavel, centro, cobranca) =>
                {
                    if(planosPagamentos.SingleOrDefault(p => p.Id == plano.Id) == null)
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
                    
                    return plano;
                } ,
                splitOn: "planoId,responsavelId,centroId,cobrancaId");

            return planosPagamentos;
        }
    }
}
