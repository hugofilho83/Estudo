using RestApiMySQLNetCore31.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiMySQLNetCore31.Services
{
    public interface IPersonService
    {
        Persons Create(Persons persons);
        Persons FindeById(long Id);
        List<Persons> FindAll();
        Persons Update(Persons person);
        void Delete(long ID);
    }
}
