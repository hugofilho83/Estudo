using System.Collections.Generic;
using System.Threading.Tasks;
namespace Backend.Repository.Contract {
    public interface IUsuarioRepository<T> where T : class {
        Task Add (T Object);
        Task Update (T Object);
        Task Delete (T Object);
        Task<T> GetEntityById (int id);
        Task<List<T>> List ();
    }
}
