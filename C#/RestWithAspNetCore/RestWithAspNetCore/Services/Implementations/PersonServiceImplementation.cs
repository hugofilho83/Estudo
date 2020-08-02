using Microsoft.EntityFrameworkCore;
using RestWithAspNetCore.Model;
using RestWithAspNetCore.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithAspNetCore.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private int count;
        private ApplicationDBContext _context;

        public PersonServiceImplementation(ApplicationDBContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
                return person;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(long Id)
        {
            var person = _context.Persons.SingleOrDefault(p => p.Id.Equals(Id));
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }

        public List<Person> FindAll()
        {           
            return _context.Persons.ToList();
        }

        public Person FindById(long Id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(Id));
        }
                
        public Person Update(Person personNew)
        {
           // var person = _context.Persons.SingleOrDefault(p => p.Id == personNew.Id);


            _context.Persons.Update(personNew);
            return personNew;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person First Name " + i.ToString() ,
                LastName = "Person Last Name" + i.ToString(),
                Address = "Some Adress " + i.ToString(),
                Gender = "Male " + i.ToString()
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

    }
}
