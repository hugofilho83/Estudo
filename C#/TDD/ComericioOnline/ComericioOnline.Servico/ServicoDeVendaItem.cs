using ComercioOnline.Validaticao;
using ComericioOnline.Model;
using dn32.infraestrutura.Atributos;
using dn32.infraestrutura.Fabrica;
using dn32.infraestrutura.Generico;
using System;

namespace ComercioOnline.Servico
{
    [ServicoDe(typeof(VendaItem))]
    public class ServicoDeVendaItem : ServicoGenerico<VendaItem>
    {
        public VendaItem Cadastre(int codigoVenda, int codigoProduto, int quantidade) 
        {
            var servicoVenda = FabricaDeServico.Crie<Venda>();
            var servicoProduto = FabricaDeServico.Crie<Produto>();

            var venda = servicoVenda.Consulte(codigoVenda);
            var produto = servicoProduto.Consulte(codigoProduto);

            var validacaoDeVendaItem = FabricaDeValidacao.Crie<VendaItem>() as ValidacaoVendaItem;
            validacaoDeVendaItem.Cadastre(produto, venda, quantidade);

            var vendaItem = new VendaItem
            {
                Desconto = 0m,
                IdVenda = venda.Id,
                IdProduto = produto.Id,
                Quntidade = quantidade                
            };

            vendaItem.ValorTotal = (produto.Valor * quantidade) - vendaItem.Desconto;           

            if(quantidade >= 10) 
            {
                vendaItem.Desconto = vendaItem.ValorTotal * 10 / 100;
            }

            vendaItem.ValorTotal -= vendaItem.Desconto;

            Cadastre(vendaItem);

            return vendaItem;
        }

        public override void Remova(int Codigo)
        {
            var servicoVenda = FabricaDeServico.Crie<Venda>();
            var servicoProduto = FabricaDeServico.Crie<Produto>();



            base.Remova(Codigo);
        }
    }
}
