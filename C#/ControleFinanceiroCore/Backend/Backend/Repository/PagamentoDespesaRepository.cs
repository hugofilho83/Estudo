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
    public class PagamentoDespesaRepository : IPagamentoDespesaRepository<PagamentoDespesa>
    {
        private readonly DataBaseContext _dataBase;

        public PagamentoDespesaRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task Add(PagamentoDespesa Entity)
        {
            ValidarEntidade(Entity);

            if (Entity.Notifications.Count == 0)
            {
                _dataBase.Add(Entity);

                await _dataBase.SaveChangesAsync();
            }
        }

        public Task Delete(PagamentoDespesa Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<PagamentoDespesa> GetEntityById(int Id)
        {
            return await _dataBase.PagamentoDespesas.FindAsync(Id);
        }

        public async Task<List<PagamentoDespesa>> List()
        {
            return await _dataBase.PagamentoDespesas.AsNoTracking().OrderBy(s => s.Id).ToListAsync();
        }

        public async Task Update(PagamentoDespesa Entity)
        {
            ValidarEntidade(Entity);

            if (Entity.Notifications.Count > 0)
                return;

            var Pagamento = _dataBase.PagamentoDespesas.Find(Entity.Id);

            Pagamento.ValorPago = Entity.ValorPago;
            Pagamento.DataPagto = Entity.DataPagto;
            Pagamento.ContaId = Pagamento.ContaId;

            _dataBase.Update(Pagamento);

            await _dataBase.SaveChangesAsync();
        }

        public void ValidarEntidade(PagamentoDespesa Entity)
        {
            Entity.ValidationPropertyInteger(Entity.ParcelaId, nameof(Entity.ParcelaId));
            Entity.ValidationPropertyDecimal(Entity.ValorPago, nameof(Entity.ValorPago));
            Entity.ValidationPropertyDateTime(Entity.DataPagto, nameof(Entity.DataPagto));
            Entity.ValidationPropertyInteger(Entity.ContaId, nameof(Entity.ContaId));
        }
    }
}
