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
    public class LancamentoDespesaRepository : ILancamentoDespesaRepository<LancamentosDespesa>
    {
        private readonly DataBaseContext _dataBase;

        public LancamentoDespesaRepository(DataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task Add(LancamentosDespesa Entity)
        {
            ValidarEntity(Entity);

            if (Entity.Notifications.Count == 0 ) 
            {
                _dataBase.Add(Entity);

                await _dataBase.SaveChangesAsync();
            }
        }

        public Task Delete(LancamentosDespesa Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<LancamentosDespesa> GetEntityById(int Id)
        {
            return await _dataBase.LancamentosDespesas.FindAsync(Id);
        }

        public async Task<List<LancamentosDespesa>> List()
        {
            return await _dataBase.LancamentosDespesas.AsNoTracking().OrderBy(s=> s.Id).ToListAsync();
        }

        public async Task Update(LancamentosDespesa Entity)
        {
            ValidarEntity(Entity);

            if (Entity.Notifications.Count > 0)
                return;

            var lancamentos = _dataBase.LancamentosDespesas.Find(Entity.Id);

            lancamentos.ContaId = Entity.ContaId;
            lancamentos.SitucaoLancamentoId = Entity.SitucaoLancamentoId;
            lancamentos.Historico = lancamentos.Historico;

            _dataBase.Update(lancamentos);

            await _dataBase.SaveChangesAsync();
        }

        private void ValidarEntity(LancamentosDespesa Entity)
        {
            Entity.ValidationPropertyInteger(Entity.UsuarioId, "Usuário");
            Entity.ValidationPropertyInteger(Entity.ContaId, "Conta");

            if (Entity.DataDespesa == DateTime.MinValue)
                Entity.ValidationPropertyString("", nameof(Entity.DataDespesa));

            //Entity.ValidationPropertyString(Entity.Historico, nameof(Entity.Historico));
            Entity.ValidationPropertyInteger(Entity.Parcela, nameof(Entity.Parcela));
            Entity.ValidationPropertyInteger(Entity.TotalParcela, nameof(Entity.TotalParcela));
            Entity.ValidationPropertyDecimal(Entity.Valor, nameof(Entity.Valor));
            Entity.ValidationPropertyInteger(Entity.SitucaoLancamentoId, "Situacao");
        }       
    }
}
