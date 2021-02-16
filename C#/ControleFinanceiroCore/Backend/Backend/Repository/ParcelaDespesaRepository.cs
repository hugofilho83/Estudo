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
    public class ParcelaDespesaRepository : IParcelaDepesaRepository<ParcelaDespesa>
    {
        private readonly DataBaseContext _dataBase;

        public ParcelaDespesaRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task Add(ParcelaDespesa Entity)
        {
            ValidarEntidade(Entity);

            if (Entity.Notifications.Count > 0)
                return;

            _dataBase.Add(Entity);

            await _dataBase.SaveChangesAsync();
        }

        public Task Delete(ParcelaDespesa Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ParcelaDespesa> GetEntityById(int Id)
        {
            return await _dataBase.ParcelaDespesas.FindAsync(Id);
        }

        public async Task<List<ParcelaDespesa>> List()
        {
            return await _dataBase.ParcelaDespesas.AsNoTracking().OrderBy(p => p.Id).ToListAsync();
        }

        public async Task Update(ParcelaDespesa Entity)
        {
            ValidarEntidade(Entity);

            if (Entity.Notifications.Count > 0)
                return;

            var parcela = _dataBase.ParcelaDespesas.Find(Entity.Id);

            parcela.LancamentoId = Entity.Id;
            parcela.Parcela = Entity.Parcela;
            parcela.Valor = Entity.Valor;
            parcela.ValorPago = Entity.ValorPago;
            parcela.DataPagto = Entity.DataPagto;
            parcela.Historico = Entity.Historico;

            _dataBase.Update(parcela);

            await _dataBase.SaveChangesAsync();
        }

        private void ValidarEntidade(ParcelaDespesa Entity)
        {
            Entity.ValidationPropertyInteger(Entity.LancamentoId, nameof(Entity.LancamentoId));
            Entity.ValidationPropertyInteger(Entity.Parcela, nameof(Entity.Parcela));
            Entity.ValidationPropertyDecimal(Entity.Valor, nameof(Entity.Valor));
        }
    }
}
