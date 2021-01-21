using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository.Contract {
    public interface ILancamentoReceitaRepository<T> where T : class {
        Task Add (T Entity);
        Task Update (T Entity);
        Task Delete (T Entity);
        Task<T> GetEntityById (int Id);
        Task<List<T>> List ();
    }
}
