using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Contract {
    public class LancamentoReceitaRepository : ILancamentoReceitaRepository<LancamentosReceita> {
        private readonly DataBaseContext _dataBase;

        public LancamentoReceitaRepository (DataBaseContext dataBase) {
            _dataBase = dataBase;
        }
        public async Task Add (LancamentosReceita Entity) {
            ValidarEntity (Entity);

            if (Entity.Notifications.Count == 0) {
                _dataBase.Add (Entity);

                await _dataBase.SaveChangesAsync ();
            }
        }

        public Task Delete (LancamentosReceita Entity) {
            throw new NotImplementedException ();
        }

        public async Task<LancamentosReceita> GetEntityById (int Id) {
            return await _dataBase.LancamentosReceitas.FindAsync (Id);
        }

        public async Task<List<LancamentosReceita>> List () {
            return await _dataBase.LancamentosReceitas.AsNoTracking ().OrderBy (s => s.Id).ToListAsync ();
        }

        public async Task Update (LancamentosReceita Entity) {
            ValidarEntity (Entity);

            if (Entity.Notifications.Count > 0)
                return;

            var lancamentos = _dataBase.LancamentosDespesas.Find (Entity.Id);

            lancamentos.Conta.Codigo = Entity.Conta.Codigo;
            lancamentos.SitucaoLancamento.Codigo = Entity.SitucaoLancamento.Codigo;
            lancamentos.Historico = lancamentos.Historico;

            _dataBase.Update (lancamentos);

            await _dataBase.SaveChangesAsync ();
        }

        private void ValidarEntity (LancamentosReceita Entity) {
            Entity.ValidationPropertyInteger (Entity.Usuario.Id, "Usuário");
            Entity.ValidationPropertyString (Entity.Conta.Codigo, "Conta");

            if (Entity.DataReceita == DateTime.MinValue)
                Entity.ValidationPropertyString ("", nameof (Entity.DataReceita));

            Entity.ValidationPropertyString (Entity.Historico, nameof (Entity.Historico));
            Entity.ValidationPropertyInteger (Entity.Parcela, nameof (Entity.Parcela));
            Entity.ValidationPropertyInteger (Entity.TotalParcela, nameof (Entity.TotalParcela));
            Entity.ValidationPropertyDecimal (Entity.Valor, nameof (Entity.Valor));
            Entity.ValidationPropertyInteger (Entity.SitucaoLancamento.Id, "Situacao");
        }
    }
}
