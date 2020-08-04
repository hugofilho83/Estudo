using AcessandoApiRest.Model;
using Refit;
using System.Threading.Tasks;

namespace AcessandoApiRest.Controller
{
    public interface ISessionApiService
    {
        [Post("/session/login")]
        Task<Token> PostLoginAsync(string json);
    }
}
