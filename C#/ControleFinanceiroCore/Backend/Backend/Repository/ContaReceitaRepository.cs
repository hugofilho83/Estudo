using Backend.Models;
using Backend.Repository.Context;
using Backend.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public class ContaReceitaRepository : IContaReceitaRepository<ContaReceita>
    {
        private DataBaseContext _dataBase;
        public ContaReceitaRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }
        public async Task Add(ContaReceita Entity)
        {
            ValidarConta(Entity);

            _dataBase.ContaReceita.Add(Entity);
            await _dataBase.SaveChangesAsync();
        }

        public Task Delete(ContaReceita Entity)
        {
            throw new NotImplementedException();
        }

        public Task<ContaReceita> GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ContaReceita>> List()
        {
            throw new NotImplementedException();
        }

        public Task Update(ContaReceita Entity)
        {
            throw new NotImplementedException();
        }

        private void ValidarConta(ContaReceita contaReceita) 
        {
            contaReceita.ValidationPropertyString(contaReceita.Codigo, nameof(contaReceita.Codigo));
            contaReceita.ValidationPropertyString(contaReceita.Descricao, nameof(contaReceita.Descricao));
        }
    }
}
