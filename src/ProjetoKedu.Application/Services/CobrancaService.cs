using ProjetoKedu.Application.DTOs;
using ProjetoKedu.Application.Interfaces;
using ProjetoKedu.Core.Entities;
using ProjetoKedu.Core.Enums;
using ProjetoKedu.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Application.Services
{
    public class CobrancaService : ICobrancaService
    {
        private readonly ICobrancaRep _cobrancaRep;
        public CobrancaService(ICobrancaRep cobrancaRep)
        {
            _cobrancaRep = cobrancaRep;
        }

        public async Task<CobrancaDto> RegistraCobranca(Guid id, RegistoPagamentoDto registoPagamento)
        {
            var registrado = await _cobrancaRep.RegistrarPagamento(new RegistroPagamento(id, registoPagamento.Valor, registoPagamento.DataPagemento));
            var novoStatus = registrado.Vencimento > DateTime.Now ? EStatusCobranca.VENCIDA : registrado.StatusCobranca;
            return new CobrancaDto(
                registrado.Id, 
                registrado.Numero, 
                registrado.Valor, 
                registrado.Vencimento, 
                registrado.MetodoPagamento, 
                novoStatus, 
                registrado.CodigoPagamento
                );
            
        }
    }
}
