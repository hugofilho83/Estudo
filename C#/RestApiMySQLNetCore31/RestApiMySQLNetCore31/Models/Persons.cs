using System;
using System.Collections.Generic;

namespace RestApiMySQLNetCore31.Models
{
    public partial class Persons
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
