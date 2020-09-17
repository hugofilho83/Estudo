using ComercioOnline.Teste.Utilitarios;
using ComericioOnline.Model;
using dn32.infraestrutura.Fabrica;
using dn32.infraestrutura.Generico;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ComercioOnline.Teste
{
    public class VendaTeste : TesteGenerico<Venda>
    {
        public override void InicializarInfraestrutura()
        {
            UtilitariosDeTeste.InicializarInfraestrutura();
        }

        [Fact(DisplayName = "VendaCadastroTeste")]
        public void VendaCadastroTeste() 
        {
            var servico = FabricaDeServico.Crie<Venda>();
            var venda = CadastrarVenda();

            Assert.NotEqual(0, venda.Codigo);

            servico.Remova(venda.Codigo);
        }

        [Fact(DisplayName = "VendaConsultaTeste")]
        public void VendaConsultaTeste() 
        {
            var servico = FabricaDeServico.Crie<Venda>();
            var venda = CadastrarVenda();

            var vendaDoBancoDeDados = servico.Consulte(venda.Codigo);

            var isTrue = Compare(venda, vendaDoBancoDeDados, nameof(venda.DataDeCadastro), nameof(venda.DataDeAtualizacao));

            Assert.True(isTrue);

            servico.Remova(venda.Codigo);
        }

        public static Venda CadastrarVenda() 
        {
            var servico = FabricaDeServico.Crie<Venda>();
            var venda = obertVenda();

            servico.Cadastre(venda);

            return venda;
        }

        private static Venda obertVenda()
        {
            return new Venda
            {
                Status = eStatusVenda.NOVA,
                ValorTotal = 0m,
                DescontoTotal = 0m
            };
        }

    }
}
