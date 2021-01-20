using Backend.Models;
using Backend.Repository.Context;
using Backend.Repository.Contract;
using Microsoft.EntityFrameworkCore;
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

            if (Entity.Notifications.Count == 0)
            {
                Entity.Ativo = true;
                _dataBase.ContaReceita.Add(Entity);
                await _dataBase.SaveChangesAsync();
            }
        }

        public Task Delete(ContaReceita Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ContaReceita> GetEntityById(int Id)
        {
            return await _dataBase.ContaReceita.FindAsync(Id);
        }

        public async Task<List<ContaReceita>> List()
        {
            return await _dataBase.ContaReceita.AsNoTracking().OrderBy(c=>c.Id).ToListAsync();
        }

        public async Task Update(ContaReceita Entity)
        {
            ValidarConta(Entity);

            if (Entity.Notifications.Count > 0) 
            {
                return;
            }

            ContaReceita conta = _dataBase.ContaReceita.Where(c => c.Id == Entity.Id).FirstOrDefault();

            conta.Codigo = Entity.Codigo;
            conta.Descricao = Entity.Descricao;
            conta.Ativo = Entity.Ativo;

            _dataBase.Update(conta);

            await _dataBase.SaveChangesAsync();
        }

        private void ValidarConta(ContaReceita contaReceita) 
        {
            contaReceita.ValidationPropertyString(contaReceita.Codigo, nameof(contaReceita.Codigo));
            contaReceita.ValidationPropertyString(contaReceita.Descricao, nameof(contaReceita.Descricao));
        }
    }
}
