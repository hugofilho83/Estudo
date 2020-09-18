using Domain.Interfaces.Generics;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generic
{
    public class RepositoryGenerics<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> OptionsBuilder;

        public RepositoryGenerics()
        {
            this.OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        #region CRUD
        public async Task Add(T objeto)
        {
            using (var data = new ContextBase(this.OptionsBuilder))
            {
                await data.Set<T>().AddAsync(objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T objeto)
        {
            using (var data = new ContextBase(this.OptionsBuilder))
            {
                data.Set<T>().Remove(objeto);
                await data.SaveChangesAsync();
            }

        }

        public async Task<T> GetEntityById(int Id)
        {
            using (var data = new ContextBase(this.OptionsBuilder))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }


        public async Task<List<T>> List()
        {
            using (var data = new ContextBase(this.OptionsBuilder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task Update(T objeto)
        {
            using (var data = new ContextBase(this.OptionsBuilder))
            {
                data.Set<T>().Update(objeto);
                await data.SaveChangesAsync();
            }
        }
        #endregion

        #region Disposed
        bool disposed = false;

        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }

            disposed = true;
        }
        #endregion  
    }
}
