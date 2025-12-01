using ProjetoKedu.Core.Entities;
using ProjetoKedu.Core.Enums;
using ProjetoKedu.Core.Interfaces;
using ProjetoKedu.InfraEstrutura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoKedu.Common.Utils;

namespace ProjetoKedu.InfraEstrutura.Repositories
{
    public class CobrancaRep : ICobrancaRep
    {
        private IDbContext Context;
        public CobrancaRep(IDbContext context)
        {
            Context = context;
        }

        public async Task<Cobranca> RegistrarPagamento(RegistroPagamento registroPagamento)
        {

            var cobranca = await Context.Buscar<Cobranca>(@"
                                            SELECT id, valor, vencimento, formapagamento, status AS StatusCobranca, codigopagamento 
                                            FROM cobrancas 
                                            WHERE id = @Id;", new {Id = registroPagamento.IdCobranca});
            IEnumerable<decimal> valorTotalPago = null;

            if (cobranca.FirstOrDefault().StatusCobranca == EStatusCobranca.PARCIAL)
            {
                var idRegistroAnterior = await Context.Buscar<Guid>(@"SELECT id FROM registropagamento WHERE cobrancaid = @Id ORDER BY datapagamento DESC LIMIT 1;",
                    new {Id = registroPagamento.IdCobranca} );

                valorTotalPago = await Context.Buscar<decimal>(@"SELECT valortotalpago FROM registropagamento WHERE id = @Id ORDER BY datapagamento DESC LIMIT 1;", new { Id = idRegistroAnterior.FirstOrDefault()});
            }    

            var transacao = await Context.Transacao();
            
            try
            {
                

                var sqlRegistroPagamento = @"INSERT INTO registropagamento VALUES (@Id, @ValorPago, @DataPagamento, @CobrancaId, @ValorTotalPago)";
                var registrado = await Context.Salvar(
                    sqlRegistroPagamento, 
                    new { 
                        registroPagamento.Id, 
                        ValorPago = registroPagamento.Valor, 
                        registroPagamento.DataPagamento, 
                        CobrancaId = registroPagamento.IdCobranca, 
                        ValorTotalPago = valorTotalPago.FirstOrDefault() + registroPagamento.Valor}, 
                    transacao);

                if(registrado)
                {
                    var novoStatus = cobranca.FirstOrDefault().Valor - (valorTotalPago.FirstOrDefault()+registroPagamento.Valor) == 0 ? EStatusCobranca.PAGA : EStatusCobranca.PARCIAL;
                    var sqlAteraStatusCobranca = @"UPDATE cobrancas SET status = @Status WHERE id = @Id;";
                    var alterado = await Context.Salvar(sqlAteraStatusCobranca, new { Status = novoStatus.ToString(), Id = registroPagamento.IdCobranca }, transacao);
                    if(alterado) 
                        await transacao.CommitAsync();
                    else
                        await transacao.RollbackAsync();
                }
            }
            catch(Exception ex)
            {
                await transacao.RollbackAsync();
            }


            var novaCobranca = await Context.Buscar<Cobranca>("SELECT id, valor, vencimento, formapagamento, status AS StatusCobranca, codigopagamento FROM cobrancas WHERE id = @Id;", new { Id = registroPagamento.IdCobranca });
            
            return novaCobranca.FirstOrDefault().AjustaStatus(); 
        }
    }
}
