using ComericioOnline.Model;
using dn32.infraestrutura.Generico;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComercioOnline.Validaticao
{
    public class ValidacaoVendaItem : ValidacaoGenerica<VendaItem>
    {
        public void Cadastre(Produto produto, Venda venda, int quantidade)
        {
            throw new NotImplementedException();
        }
    }
}
