using dn32.infraestrutura;
using dn32.infraestrutura.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComercioOnline.Teste.Utilitarios
{
    public static class UtilitariosDeTeste
    {
        public static void InicializarInfraestrutura()
        {
            var parametrosDeInicializacao = new ParametrosDeInicializacao
            {
                EnderecoDeBackupDoBancoDeDados = "c:/ravendb-backup",
                EnderecoDoBancoDeDados = "http://localhost:8080",
                NomeDoAssemblyDaValidacao = "ComericioOnline.Validaticao",
                NomeDoAssemblyDoRepositorio = "ComercioOnline.Teste",
                NomeDoAssemblyDoServico = "ComercioOnline.Servico",
                NomeDoBancoDeDados = "ComercioOline"
            };

            Inicializar.Inicialize(parametrosDeInicializacao);
        }
    }
}
