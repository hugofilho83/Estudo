using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Generic
{
    public interface IGenericApp<T> where T : class
    {
        Task Add(T objeto);
        Task Update(T objeto);
        Task Delete(T objeto);
        Task<T> GetEntityById(int Id);
        Task<List<T>> List();
    }
}
