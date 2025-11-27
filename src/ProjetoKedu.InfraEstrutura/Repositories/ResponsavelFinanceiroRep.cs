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
            var gravado = await Context.Salvar(sql, new { Id = responsavel.Id, Nome = responsavel.Nome });

            if (!gravado)
            {
                Error.GetError("Não foi possivel gravar o Responsavel");
                return false;
            }
            return true;
        }
     
        public async Task<IEnumerable<ResponsavelFinanceiro>> Consultar()
        {
            var sql = "SELECT Id, Nome FROM responsaveis";
            var responsaveis = await Context.Buscar<ResponsavelFinanceiro>(sql);
            return responsaveis;
        }
        public async Task<ResponsavelFinanceiro> ConsultarPorId(Guid id)
        {
            
            var sql = @"SELECT * FROM responsaveis WHERE Id = @Id;";
            var responsavels = await Context.Buscar<ResponsavelFinanceiro>(sql, new { Id = id });

            return responsavels.FirstOrDefault();
            

        }
        public Task<ResponsavelFinanceiro> Editar(ResponsavelFinanceiro responsavel)
        {
            // cria a query update
            // fazer chamada ao banco e alterar o nome
            // retorna o novo dado
            throw new NotImplementedException();
        }

    }

}
