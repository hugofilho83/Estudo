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
    public class ContaDespesaRepository : IContaDespesaRepository<ContaDespesa>
    {
        private DataBaseContext _dataBase;

        public ContaDespesaRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task Add(ContaDespesa Entity)
        {
            ValidarConta(Entity);

            if (Entity.Notifications.Count == 0) 
            {
                _dataBase.Add(Entity);
                await _dataBase.SaveChangesAsync();
            }
        }

        public Task Delete(ContaDespesa Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ContaDespesa> GetEntityById(int Id)
        {
            return await _dataBase.ContaDespesas.FindAsync(Id);
        }

        public async Task<List<ContaDespesa>> List()
        {
            return await _dataBase.ContaDespesas.AsNoTracking().OrderBy(c=> c.Id).ToListAsync();
        }

        public async Task Update(ContaDespesa Entity)
        {
            ValidarConta(Entity);

            if(Entity.Notifications.Count > 0) 
            {
                return;
            }

            ContaDespesa conta = _dataBase.ContaDespesas.Find(Entity.Id);

            conta.Codigo = Entity.Codigo;
            conta.Descricao = Entity.Descricao;
            conta.Ativo = Entity.Ativo;

            _dataBase.Update(conta);

            await _dataBase.SaveChangesAsync();
        }

        private void ValidarConta(ContaDespesa contaReceita)
        {
            contaReceita.ValidationPropertyString(contaReceita.Codigo, nameof(contaReceita.Codigo));
            contaReceita.ValidationPropertyString(contaReceita.Descricao, nameof(contaReceita.Descricao));
        }
    }
}
