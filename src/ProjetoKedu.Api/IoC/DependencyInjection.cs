using ProjetoKedu.Application.Interfaces;
using ProjetoKedu.Application.Services;
using ProjetoKedu.Core.Interfaces;
using ProjetoKedu.InfraEstrutura;
using ProjetoKedu.InfraEstrutura.Interfaces;
using ProjetoKedu.InfraEstrutura.Repositories;

namespace ProjetoKedu.Api.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IResponsavelFinanceiroService, ResponsavelFinanceiroService>();
            services.AddScoped<ICentroCustoService, CentroDeCustoService>();
            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped<IResponsavelFinanceiroRep, ResponsavelFinanceiroRep>();
            services.AddScoped<ICentroDeCustoRep, CentroDeCustoRep>();
            return services;
        }
    }
}
