using Entitites.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entitites.Entities
{
    public class Base : Notifies
    {
        [Display(Name ="Codigo")]
        public int Id { get; set; }

        [Display(Name ="Nome")]
        public string Nome { get; set; }
    }
}
