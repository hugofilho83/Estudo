using AcessandoApiRest.Model;
using Refit;
using System;
using System.Threading.Tasks;

namespace AcessandoApiRest.Controller
{
    public interface ICepApiService
    {
        [Get("/ws/{cep}/json")]
        Task<CepResponse> GetAddressAsync(string cep);
    }
}
