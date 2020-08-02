using Microsoft.EntityFrameworkCore;

namespace RestWithAspNetCore.Model.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() { }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options){}

        public DbSet<Person> Persons;
    }
}
