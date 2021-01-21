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
    public class SituacaoLancamentoDespesaRepository : ISituacaoLancamentoDespesaRepository<SituacaoLancamentoDespesa>
    {
        private readonly DataBaseContext _dataBase;

        public SituacaoLancamentoDespesaRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task Add(SituacaoLancamentoDespesa Entity)
        {
            ValidarEntity(Entity);

            if (Entity.Notifications.Count == 0 ) 
            {
                _dataBase.Add(Entity);

                await _dataBase.SaveChangesAsync();
            }
        }

        public Task Delete(SituacaoLancamentoDespesa Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<SituacaoLancamentoDespesa> GetEntityById(int Id)
        {
            return await _dataBase.SituacaoLancamentoDesposas.FindAsync(Id);
        }

        public async Task<List<SituacaoLancamentoDespesa>> List()
        {
            return await _dataBase.SituacaoLancamentoDesposas.AsNoTracking().OrderBy(s=> s.Id).ToListAsync();
        }

        public async Task Update(SituacaoLancamentoDespesa Entity)
        {
            ValidarEntity(Entity);

            if (Entity.Notifications.Count > 0)
                return;

            var Situacao = _dataBase.SituacaoLancamentoDesposas.Find(Entity.Id);

            Situacao.Codigo = Entity.Codigo;
            Situacao.Descricao = Entity.Descricao;

            _dataBase.Update(Situacao);

            await _dataBase.SaveChangesAsync();
        }

        private void ValidarEntity(SituacaoLancamentoDespesa Entity)
        {
            Entity.ValidationPropertyInteger(Entity.Codigo, nameof(Entity.Codigo));
            Entity.ValidationPropertyString(Entity.Descricao, nameof(Entity.Descricao));
        }
    }
}
