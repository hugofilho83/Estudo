using Entitites.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configuration
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStringConection());

            base.OnConfiguring(optionsBuilder);
        }

        private string GetStringConection()
        {
            string strConnection = "Server=DESKTOP-42RSL7V;Database=DB_ESTUDO_DDD;User Id=sa;Password=htaf@1983;Integrated Security=false;MultipleActiveResultSets=true;";

            return strConnection;
        }
    }
}
