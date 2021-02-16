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
    public class RecebimentoReceitaRepository : IRecebimentoReceitaRepository<RecebimentoReceita>
    {
        private readonly DataBaseContext _dataBase;

        public RecebimentoReceitaRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }


        public async Task Add(RecebimentoReceita Entity)
        {
            ValidarEntity(Entity);

            if (Entity.Notifications.Count > 0)
                return;

            _dataBase.Add(Entity);

            await _dataBase.SaveChangesAsync();
        }

        public Task Delete(RecebimentoReceita Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<RecebimentoReceita> GetEntityById(int Id)
        {
            return await _dataBase.RecebimentoReceitas.FindAsync(Id);
        }

        public async Task<List<RecebimentoReceita>> List()
        {
            return await _dataBase.RecebimentoReceitas.AsNoTracking().OrderBy(r => r.Id).ToListAsync();
        }

        public async Task Update(RecebimentoReceita Entity)
        {
            ValidarEntity(Entity);

            if (Entity.Notifications.Count > 0)
                return;

            var recebimento = _dataBase.RecebimentoReceitas.Find(Entity.Id);

            recebimento.ParcelaReceitaId = Entity.ParcelaReceitaId;
            recebimento.ValorPago = Entity.ValorPago;
            recebimento.DataReceb = Entity.DataReceb;
            recebimento.Historico = Entity.Historico;

            _dataBase.Update(recebimento);

            await _dataBase.SaveChangesAsync();
        }

        private void ValidarEntity(RecebimentoReceita Entity) 
        {
            Entity.ValidationPropertyInteger(Entity.ParcelaReceitaId, nameof(Entity.ParcelaReceitaId));
            Entity.ValidationPropertyDecimal(Entity.ValorPago, nameof(Entity.ValorPago));
            Entity.ValidationPropertyDateTime(Entity.DataReceb, nameof(Entity.DataReceb)); 
            Entity.ValidationPropertyString(Entity.Historico, nameof(Entity.Historico));
        }
    }
}
