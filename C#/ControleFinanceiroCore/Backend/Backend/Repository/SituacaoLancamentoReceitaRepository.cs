﻿using Backend.Models;
using Backend.Repository.Context;
using Backend.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public class SituacaoLancamentoReceitaRepository : ISituacaoLancamentoReceitaRepository<SituacaoLancamentoReceita>
    {
        private readonly DataBaseContext _dataBase;

        public SituacaoLancamentoReceitaRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task Add(SituacaoLancamentoReceita Entity)
        {
            ValidarEntity(Entity);

            if (Entity.Notifications.Count == 0 ) 
            {
                _dataBase.Add(Entity);

                await _dataBase.SaveChangesAsync();
            }
        }

        public Task Delete(SituacaoLancamentoReceita Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<SituacaoLancamentoReceita> GetEntityById(int Id)
        {
            return await _dataBase.SituacaoLancamentoReceita.FindAsync(Id);
        }

        public async Task<List<SituacaoLancamentoReceita>> List()
        {
            return await _dataBase.SituacaoLancamentoReceita.AsNoTracking().OrderBy(s=> s.Id).ToListAsync();
        }

        public async Task Update(SituacaoLancamentoReceita Entity)
        {
            ValidarEntity(Entity);

            if (Entity.Notifications.Count > 0)
                return;

            var Situacao = _dataBase.SituacaoLancamentoReceita.Find(Entity.Id);

            Situacao.Codigo = Entity.Codigo;
            Situacao.Descricao = Entity.Descricao;

            _dataBase.Update(Situacao);

            await _dataBase.SaveChangesAsync();
        }

        private void ValidarEntity(SituacaoLancamentoReceita Entity)
        {
            Entity.ValidationPropertyInteger(Entity.Codigo, nameof(Entity.Codigo));
            Entity.ValidationPropertyString(Entity.Descricao, nameof(Entity.Descricao));
        }
    }
}
