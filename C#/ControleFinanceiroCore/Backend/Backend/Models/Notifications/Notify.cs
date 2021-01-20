using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Notifications
{
    public class Notify
    {
        [NotMapped]
        public string NameProperty { get; set; }

        [NotMapped]
        public string Messager { get; set; }
    }
}
