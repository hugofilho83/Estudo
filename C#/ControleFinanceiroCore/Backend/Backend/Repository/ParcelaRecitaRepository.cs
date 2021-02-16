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
    public class ParcelaRecitaRepository : IParcelaReceitaRepository<ParcelaReceita>
    {
        private readonly DataBaseContext _dataBase;
        public ParcelaRecitaRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }
        public async Task Add(ParcelaReceita Entity)
        {
            ValidarEntity(Entity);

            if (Entity.Notifications.Count > 0)
                return;

            _dataBase.Add(Entity);

            await _dataBase.SaveChangesAsync();
        }

        public Task Delete(ParcelaReceita Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ParcelaReceita> GetEntityById(int Id)
        {
            return await _dataBase.ParcelaReceitas.FindAsync(Id);
        }

        public async Task<List<ParcelaReceita>> List()
        {
            return await _dataBase.ParcelaReceitas.AsNoTracking().OrderBy(p => p.Id).ToListAsync();
        }

        public async Task Update(ParcelaReceita Entity)
        {
            ValidarEntity(Entity);

            if (Entity.Notifications.Count > 0)
                return;

            var parcela = _dataBase.ParcelaReceitas.Find(Entity.Id);

            parcela.LancamentoId = Entity.LancamentoId;
            parcela.Parcela = Entity.Parcela;
            parcela.Valor = Entity.Valor;
            parcela.ValorRecebido = Entity.ValorRecebido;
            parcela.DataRecebido = Entity.DataRecebido;
            parcela.Historico = Entity.Historico;

            _dataBase.Update(parcela);

            await _dataBase.SaveChangesAsync();
        }

        private void ValidarEntity(ParcelaReceita Entity)
        {
            Entity.ValidationPropertyInteger(Entity.LancamentoId, nameof(Entity.LancamentoId));
            Entity.ValidationPropertyInteger(Entity.Parcela, nameof(Entity.Parcela));
            Entity.ValidationPropertyDecimal(Entity.Valor, nameof(Entity.Valor));
        }
    }
}
