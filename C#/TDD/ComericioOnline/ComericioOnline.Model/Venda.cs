using dn32.infraestrutura.Generico;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace ComericioOnline.Model
{
    public class Venda : ModelGenerico
    {
        public eStatusVenda Status { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal DescontoTotal { get; set; }
    }
}
