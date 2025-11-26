using ProjetoKedu.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoKedu.Core.Interfaces
{
    public interface IRepository
    {
        Task<bool> Cadastrar<T>(T objeto);
        Task<T> ConsultarPorId<T>(Guid id);
        Task<IEnumerable<T>> ConsultarPorId<T>();
        Task<T> EditarPlano<T,U>(U planoDePagamento);
    }
}
