using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entitites.Entities
{
    public class Product : Base
    {
        [Display(Name ="Preço")]
        public decimal Preco { get; set; }

        [Display(Name ="Ativo")]
        public bool Ativo { get; set; }
    }
}
