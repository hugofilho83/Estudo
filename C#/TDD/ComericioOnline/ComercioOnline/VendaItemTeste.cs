using ComercioOnline.Teste.Utilitarios;
using ComericioOnline.Model;
using dn32.infraestrutura.Fabrica;
using dn32.infraestrutura.Generico;
using Xunit;
using ComercioOnline.Servico;
using System;
using ComericioOnline.Model.UtilitariosDoModel;

namespace ComercioOnline.Teste
{
    public class VendaItemTeste : TesteGenerico<VendaItem>
    {
        public override void InicializarInfraestrutura()
        {
            UtilitariosDeTeste.InicializarInfraestrutura();
        }

        [Fact(DisplayName = nameof(AcidionarItemNaVenda))]
        public void AcidionarItemNaVenda() 
        {
            var servico = FabricaDeServico.Crie<VendaItem>() as ServicoDeVendaItem;

            var venda = VendaTeste.CadastrarVenda();
            var produto = ProdutoTeste.CadastrarProduto();

            var vendaItem = servico.Cadastre(venda.Codigo, produto.Codigo, 10);

            Assert.NotEqual(0, vendaItem.Codigo);

            //Todo Remover lixo do Banco
        }

        [Fact(DisplayName = nameof(AcidionarProdutoInvalidoNaProdutoError))]
        public void AcidionarProdutoInvalidoNaProdutoError()
        {
            var servico = FabricaDeServico.Crie<VendaItem>() as ServicoDeVendaItem;

            var venda = VendaTeste.CadastrarVenda();
            var produto = ObtenhaUmCodigo();


            var ex = Assert.Throws<Exception>(() => { 
                servico.Cadastre(venda.Codigo, produto, 10); 
            });

            Assert.Equal(ex.Message, ConstantesDeValidacaoDoModel.PRODUTO_INFORMADO_NAO_LOCALIZADO);


        }

        [Fact(DisplayName = nameof(AcidionarProdutoNaVendaInvalidaError))]
        public void AcidionarProdutoNaVendaInvalidaError()
        {
            var servico = FabricaDeServico.Crie<VendaItem>() as ServicoDeVendaItem;

            var venda = ObtenhaUmCodigo();
            var produto = ProdutoTeste.CadastrarProduto();


            var ex = Assert.Throws<Exception>(() => {
                servico.Cadastre(venda, produto.Codigo, 10) ;
            });

            Assert.Equal(ex.Message, ConstantesDeValidacaoDoModel.VENDA_INFORMADA_NAO_LOCALICADA);
        }

        [Fact(DisplayName = nameof(RemoverItemVenda))]
        public void RemoverItemVenda() 
        {

        }

        [Fact(DisplayName = nameof(RemoverItemVendaFechada))]
        public void RemoverItemVendaFechada()
        {

        }

    }
}
