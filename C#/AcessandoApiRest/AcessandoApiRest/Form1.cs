using AcessandoApiRest.Controller;
using AcessandoApiRest.Model;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcessandoApiRest
{
    public partial class Form1 : Form
    {
        private readonly string URL_VIA_CEP = "http://viacep.com.br";
        private readonly string URL_API = "http://213.139.204.157:49380/api/v1";
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await GetCep(txtCEP.Text);
        }

        private async Task GetCep(string cep) 
        {
            try
            {
                var cepClient = RestService.For<ICepApiService>(URL_VIA_CEP);

                CepResponse address = await cepClient.GetAddressAsync(cep);

                txtLogradouro.Text = address.Logradrouro;
                txtBairro.Text = address.Bairro;
                txtCidade.Text = address.Localidade;
                txtUF.Text = address.Uf;
                txtIbge.Text = address.Ibge;
                txtUnidade.Text = address.Unidade;
                txtGia.Text = address.Gia;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task AcessarApi() 
        {
            try
            {
                var usuario = new Usuario();
                usuario.Login = "hugo";
                usuario.Senha = "hf@1983";

                var tokenApi = RestService.For<ISessionApiService>("http://213.139.204.157:49380/api/v1");

                string json = JsonConvert.SerializeObject(usuario);

                var token = await tokenApi.PostLoginAsync(json);

                dataGridView1.DataSource = tokenApi;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private async void Form1_Load(object sender, EventArgs e)
        {
            await AcessarApi();
        }
    }
}
