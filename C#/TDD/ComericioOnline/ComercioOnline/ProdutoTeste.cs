using ComericioOnline.Model;
using dn32.infraestrutura;
using dn32.infraestrutura.Fabrica;
using dn32.infraestrutura.Model;
using System;
using Xunit;

namespace ComercioOnline
{
    public class ProdutoTeste
    {
        private void InicializarInfraestrutura()
        {
            var parametrosDeInicializacao = new ParametrosDeInicializacao
            {
                EnderecoDeBackupDoBancoDeDados = "c:/ravendb-backup",
                EnderecoDoBancoDeDados = "http://localhost:8080",
                NomeDoAssemblyDaValidacao = "MinhaAplicacao.Validacao",
                NomeDoAssemblyDoRepositorio = "MinhaAplicacao.Repositorio",
                NomeDoAssemblyDoServico = "MinhaAplicacao.Servico",
                NomeDoBancoDeDados = "banco-de-dados-de-minha-aplicacao"
            };

            Inicializar.Inicialize(parametrosDeInicializacao);
        }


        [Fact]
        public void Cadastro()
        {
            var produto = new Produto
            {
                Nome = "Computador com impressora.",
                Valor = 1285.58m,
                CodigoDeBarras = "786456978796"
            };

            var servico = FabricaDeServico.Crie<Produto>();

            servico.Cadastre(produto);

            Assert.NotEqual(0, produto.Codigo);
        }
    }
}
