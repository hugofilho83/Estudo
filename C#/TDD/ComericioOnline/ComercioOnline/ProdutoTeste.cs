using System;
using Xunit;

namespace ComercioOnline
{
    public class ProdutoTeste
    {
        [Fact]
        public void Cadastro()
        {
            var produto = new Produto
            {
                Nome = "Computador com impressora.",
                Valor = 1285.58m,
                CodigoDeBarras = "786456978796"
            };

            Cadastre(Produto);

            Assert.NotEqual(produto.Codigo, 0);
        }
    }
}
