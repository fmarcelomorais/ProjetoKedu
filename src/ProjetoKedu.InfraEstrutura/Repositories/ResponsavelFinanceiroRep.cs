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
            var sql = @"INSERT INTO responsavel (id, nome) VALUES (@Id, @Nome);";
            var gravado = await Context.Salvar(sql, new {Id = responsavel.Id, Nome = responsavel.NomeResponsavel()});
            
            if (!gravado)
                Error.GetError("Não foi possivel gravar a informação");
            return true;
        }

        public Task<ResponsavelFinanceiro> ConsultarPorId<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ResponsavelFinanceiro>> ConsultarPorId<T>()
        {
            throw new NotImplementedException();
        }

        public Task<ResponsavelFinanceiro> EditarPlano(ResponsavelFinanceiro responsavel)
        {
            throw new NotImplementedException();
        }
    }
}
