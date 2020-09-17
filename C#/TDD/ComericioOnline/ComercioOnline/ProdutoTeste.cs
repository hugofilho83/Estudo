using ComercioOnline.Teste.Utilitarios;
using ComericioOnline.Model;
using ComericioOnline.Model.UtilitariosDoModel;
using dn32.infraestrutura;
using dn32.infraestrutura.Constantes;
using dn32.infraestrutura.Fabrica;
using dn32.infraestrutura.Generico;
using dn32.infraestrutura.Model;
using Raven.Client.Linq.Indexing;
using System;
using Xunit;

namespace ComercioOnline
{
    public class ProdutoTeste : TesteGenerico<Produto>
    {
        public override void InicializarInfraestrutura()
        {
            UtilitariosDeTeste.InicializarInfraestrutura();
        }

        #region CADASTRO

        [Fact(DisplayName ="ProdutoCadastroTeste")]
        public void Cadastro()
        {
            var servico = FabricaDeServico.Crie<Produto>();
            var produto = CadastrarProduto();

            Assert.NotEqual(0, produto.Codigo);
            servico.Remova(produto.Codigo);
        }

        [Fact(DisplayName = "ProdutoCadastroSemValorErrorTeste")]
        public void CadastroSemValorErroTeste() 
        {
            Produto produto = ObterModelProduto();
            produto.Valor = 0;

            var servico = FabricaDeServico.Crie<Produto>();

            var ex = Assert.Throws<Exception>(() => {
                servico.Cadastre(produto);
            });
                                   

            Assert.Equal(ConstantesDeValidacaoDoModel.VALOR_PRODUTO_OBRIGATORIO, ex.Message);
        }

        [Fact(DisplayName = "ProdutoCadastroSemNomeErrorTeste")]
        public void CadastroSemNomeErroTeste()
        {
            Produto produto= ObterModelProduto();
            produto.Nome = String.Empty;


            var servico = FabricaDeServico.Crie<Produto>();

            var ex = Assert.Throws<Exception>(() => {
                servico.Cadastre(produto);
            });


            Assert.Equal(ex.Message, ConstantesDeValidacao.O_NOME_DO_ELEMENTO_DEVE_SER_INFORMADO);
        }

        #endregion

        #region CONSULTA

        [Fact(DisplayName = "ProdutoConsultaTeste")]
        public void ConsultaTeste()
        {
            var servico = FabricaDeServico.Crie<Produto>();
            var produto = CadastrarProduto();

            var produtoDoBanco = servico.Consulte(produto.Codigo);

            var isEqual = Compare(produto, produtoDoBanco, nameof(Produto.DataDeAtualizacao), nameof(Produto.DataDeCadastro));

            Assert.True(isEqual);

            servico.Remova(produto.Codigo);
        }

        #endregion


        #region ATUALIZACAO
        [Fact(DisplayName = "ProdutoAtualizarSemValorErroTeste")]
        public void AtualizarSemValorErroTeste()
        {
            Produto produto = CadastrarProduto();
            produto.Valor = 0;

            var servico = FabricaDeServico.Crie<Produto>();

            var ex = Assert.Throws<Exception>(() => {
                servico.Atualize(produto);
            });


            Assert.Equal(ConstantesDeValidacaoDoModel.VALOR_PRODUTO_OBRIGATORIO, ex.Message);

            servico.Remova(produto.Codigo);
        }

        [Fact(DisplayName = "ProdutoAtualizarSemNomeErroTeste")]
        public void AtualizarSemNomeErroTeste()
        {
            Produto produto = CadastrarProduto();
            produto.Nome = String.Empty;


            var servico = FabricaDeServico.Crie<Produto>();

            var ex = Assert.Throws<Exception>(() => {
                servico.Atualize(produto);
            });


            Assert.Equal(ex.Message, ConstantesDeValidacao.O_NOME_DO_ELEMENTO_DEVE_SER_INFORMADO);

            servico.Remova(produto.Codigo);
        }

        #endregion

        #region Metodos Privados

        public static Produto ObterModelProduto()
        {
            return new Produto
            {
                Nome = "SmartPhone Motorola Moto G8 Plus",
                Valor = 1480.58m,
                CodigoDeBarras = "786456978787"
            };
        }

        public static Produto CadastrarProduto() 
        {
            var servico = FabricaDeServico.Crie<Produto>();
            var produto = ObterModelProduto();

            servico.Cadastre(produto);

            return produto;
        }

        #endregion

    }
}
