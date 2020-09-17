using ComericioOnline.Model;
using ComericioOnline.Model.UtilitariosDoModel;
using dn32.infraestrutura.Atributos;
using dn32.infraestrutura.Generico;
using System;

namespace ComercioOnline.Validaticao
{
    [ValidacaoDe(typeof(Produto))]
    public class ValidacaoProduto : ValidacaoGenericaComNome<Produto>
    {
        public override void Cadastre(Produto item)
        {
            if(item.Valor == 0) 
            {
                throw new Exception(ConstantesDeValidacaoDoModel.VALOR_PRODUTO_OBRIGATORIO);
            }

            base.Cadastre(item);
        }

        public override void Atualize(Produto item)
        {
            if (item.Valor == 0)
            {
                throw new Exception(ConstantesDeValidacaoDoModel.VALOR_PRODUTO_OBRIGATORIO);
            }

            base.Atualize(item);
        }

    }
}
