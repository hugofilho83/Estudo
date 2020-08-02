using RestApiMySQLNetCore31.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiMySQLNetCore31.Services.Implementations
{

    public class PersonsImplementation : IPersonService
    {
        private ApplicationDbContext context;

        public PersonsImplementation(ApplicationDbContext context)
        {
            this.context = context;
        }


        public Persons Create(Persons persons)
        {
            this.context.Persons.Add(persons);
            this.context.SaveChanges();

            return persons;
        }

        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<Persons> FindAll()
        {
            throw new NotImplementedException();
        }

        public Persons FindeById(long Id)
        {
            throw new NotImplementedException();
        }

        public Persons Update(Persons person)
        {
            throw new NotImplementedException();
        }
    }
}
