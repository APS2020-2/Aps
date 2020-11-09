using Aps.DTO;
using Aps.Formularios;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows.Forms;

namespace Aps
{
    public partial class Form2 : Form
    {
        public int m = 0;
        private bool isCollapsed;
        public Form2()
        {
            InitializeComponent();

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            GetAllProdutos(0, "Inicio");
            
        }
        private async void GetAllProdutos(int i, string paginas)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync("http://localhost:5000/CatalogoFilmesAPI/filme/"))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            Form1 form = new Form1();
                            
                            var ProdutoJsonString = await response.Content.ReadAsStringAsync();

                            var objData = JsonConvert.DeserializeObject<List<DadosFilmes>>(ProdutoJsonString);
                            
                            carregarPainel(objData, i, paginas);
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível obter o produto : " + response.StatusCode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(),"Error");
            }
        }
        private async void GetAllDiretores(int i, string paginas)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync("http://localhost:5000/CatalogoFilmesAPI/diretor/"))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            Form1 form = new Form1();

                            var ProdutoJsonString = await response.Content.ReadAsStringAsync();

                            var objDiretor = JsonConvert.DeserializeObject<List<DTO_Diretor>>(ProdutoJsonString);

                            carregarDiretor(objDiretor, i, paginas);
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível obter o produto : " + response.StatusCode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private async void GetAllGeneroFilme(int i, string paginas,string genero)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync("http://localhost:5000/CatalogoFilmesAPI/diretor/"))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            Form1 form = new Form1();

                            var ProdutoJsonString = await response.Content.ReadAsStringAsync();

                            var objDiretor = JsonConvert.DeserializeObject<List<DTO_Filme>>(ProdutoJsonString);

                            carregarGenero(objDiretor, i, paginas, genero);
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível obter o produto : " + response.StatusCode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error");
            }
        }
        public void carregarPainel(List<DadosFilmes> objData, int i, string inicio)
        {
            try
            {
                btnProxima.Enabled = true;
                if (inicio == "Inicio")
                {
                    btnAnterior.Enabled = false;
                }
                else
                {
                    btnAnterior.Enabled = true;

                }

                if (i < objData.Count)
                {


                    lblDuracao1.Text = "Duração: ";
                    lblGenero1.Text = "Gênero: ";
                    txtFilme1.Text = objData[i].titulo;
                    txtDuracao1.Text = objData[i].duracao;
                    txtGenero1.Text = objData[i].generoId.ToString();
                    txtLancamento1.Text = objData[i].dataLancamento.ToString();
                    txtIdioma1.Text = objData[i].idiomaOriginal;
                    txtDiretor1.Text = objData[i].diretor.nome;
                    txtDescricao1.Text = objData[i].descricao;

                    txtLancamento1.Visible = true;
                    lblLancamento1.Visible = true;
                    txtIdioma1.Visible = true;
                    lblIdioma1.Visible = true;
                    txtDiretor1.Visible = true;
                    lblDiretor1.Visible = true;
                    panel2.Visible = true;
                    
                }
                else
                {
                    panel3.Hide();
                    if((i + 1) > objData.Count)
                    {
                        btnProxima.Enabled = false;
                    }
                }
                if ((i + 1) < objData.Count)
                {

                    lblDuracao2.Text = "Duração: ";
                    lblGenero2.Text = "Gênero: ";
                    txtFilme2.Text = objData[i + 1].titulo;
                    txtDuracao2.Text = objData[i + 1].duracao;
                    txtGenero2.Text = objData[i + 1].generoId.ToString();
                    txtLancamento2.Text = objData[i + 1].dataLancamento.ToString();
                    txtIdioma2.Text = objData[i + 1].idiomaOriginal;
                    txtDiretor2.Text = objData[i + 1].diretor.nome;
                    txtDescricao2.Text = objData[i + 1].descricao;
                    txtLancamento2.Visible = true;
                    lblLancamento2.Visible = true;
                    txtIdioma2.Visible = true;
                    lblIdioma2.Visible = true;
                    txtDiretor2.Visible = true;
                    lblDiretor2.Visible = true;
                    panel2.Visible = true;
                }
                else
                {
                    panel4.Hide();
                    if ((i + 2) > objData.Count)
                    {
                        btnProxima.Enabled = false;
                    }
                }
                if ((i + 2) < objData.Count)
                {

                    lblDuracao3.Text = "Duração: ";
                    lblGenero3.Text = "Gênero: ";
                    txtFilme3.Text = objData[i + 2].titulo;
                    txtDuracao3.Text = objData[i + 2].duracao;
                    txtGenero3.Text = objData[i + 2].generoId.ToString();
                    txtLancamento3.Text = objData[i + 2].dataLancamento.ToString();
                    txtIdioma3.Text = objData[i + 2].idiomaOriginal;
                    txtDiretor3.Text = objData[i + 2].diretor.nome;
                    txtDescricao3.Text = objData[i + 2].descricao;
                    txtLancamento3.Visible = true;
                    lblLancamento3.Visible = true;
                    txtIdioma3.Visible = true;
                    lblIdioma3.Visible = true;
                    txtDiretor3.Visible = true;
                    lblDiretor3.Visible = true;
                    panel4.Visible = true;
                }
                else
                {
                    panel5.Hide();
                    if ((i + 3) > objData.Count)
                    {
                        btnProxima.Enabled = false;
                    }
                }
                if ((i + 3) < objData.Count)
                {


                    lblDuracao4.Text = "Duração: ";
                    lblGenero4.Text = "Gênero: ";
                    txtFilme4.Text = objData[i + 3].titulo;
                    txtDuracao4.Text = objData[i + 3].duracao;
                    txtGenero4.Text = objData[i + 3].generoId.ToString();
                    txtLancamento4.Text = objData[i + 3].dataLancamento.ToString();
                    txtIdioma4.Text = objData[i + 3].idiomaOriginal;
                    txtDiretor4.Text = objData[i + 3].diretor.nome;
                    txtDescricao4.Text = objData[i + 3].descricao;

                    txtLancamento4.Visible = true;
                    lblLancamento4.Visible = true;
                    txtIdioma4.Visible = true;
                    lblIdioma4.Visible = true;
                    txtDiretor4.Visible = true;
                    lblDiretor4.Visible = true;
                    panel5.Visible = true;
                }
                else
                {
                    panel5.Hide();
                    if ((i + 4) > objData.Count)
                    {
                        btnProxima.Enabled = false;
                    }
                }
                if ((i + 4) < objData.Count)
                {

                    lblDuracao5.Text = "Duração: ";
                    lblGenero5.Text = "Gênero: ";
                    txtFilme5.Text = objData[i + 4].titulo;
                    txtDuracao5.Text = objData[i + 4].duracao;
                    txtGenero5.Text = objData[i + 4].generoId.ToString();
                    txtLancamento5.Text = objData[i + 4].dataLancamento.ToString();
                    txtIdioma5.Text = objData[i + 4].idiomaOriginal;
                    txtDiretor5.Text = objData[i + 4].diretor.nome;
                    txtDescricao5.Text = objData[i + 4].descricao;

                    txtLancamento5.Visible = true;
                    lblLancamento5.Visible = true;
                    txtIdioma5.Visible = true;
                    lblIdioma5.Visible = true;
                    txtDiretor5.Visible = true;
                    lblDiretor5.Visible = true;
                    panel6.Visible = true;
                }
                else
                {
                    if ((i + 5) > objData.Count)
                    {
                        btnProxima.Enabled = false;
                    }
                    panel6.Hide();
                }
                if ((i + 5) < objData.Count)
                {

                    lblDuracao6.Text = "Duração: ";
                    lblGenero6.Text = "Gênero: ";
                    txtFilme6.Text = objData[i + 5].titulo;
                    txtDuracao6.Text = objData[i + 5].duracao;
                    txtGenero6.Text = objData[i + 5].generoId.ToString();
                    txtLancamento6.Text = objData[i + 5].dataLancamento.ToString();
                    txtIdioma6.Text = objData[i + 5].idiomaOriginal;
                    txtDiretor6.Text = objData[i + 5].diretor.nome;
                    txtDescricao6.Text = objData[i + 5].descricao;

                    txtLancamento6.Visible = true;
                    lblLancamento6.Visible = true;
                    txtIdioma6.Visible = true;
                    lblIdioma6.Visible = true;
                    txtDiretor6.Visible = true;
                    lblDiretor6.Visible = true;
                    panel7.Visible = true;

                }
                else
                {
                    panel7.Hide();
                    if ((i + 6) > objData.Count)
                    {
                        btnProxima.Enabled = false;
                    }
                }
                if ((i + 6) < objData.Count)
                {

                    lblDuracao7.Text = "Duração: ";
                    lblGenero7.Text = "Gênero: ";
                    txtFilme7.Text = objData[i + 6].titulo;
                    txtDuracao7.Text = objData[i + 6].duracao;
                    txtGenero7.Text = objData[i + 6].generoId.ToString();
                    txtLancamento7.Text = objData[i + 6].dataLancamento.ToString();
                    txtIdioma7.Text = objData[i + 6].idiomaOriginal;
                    txtDiretor7.Text = objData[i + 6].diretor.nome;
                    txtDescricao7.Text = objData[i + 6].descricao;

                    txtLancamento7.Visible = true;
                    lblLancamento7.Visible = true;
                    txtIdioma7.Visible = true;
                    lblIdioma7.Visible = true;
                    txtDiretor7.Visible = true;
                    lblDiretor7.Visible = true;
                    panel8.Visible = true;

                }
                else
                {
                    panel8.Hide();
                    if ((i + 7) > objData.Count)
                    {
                        btnProxima.Enabled = false;
                    }
                }
                if ((i + 7) < objData.Count)
                {

                    lblDuracao8.Text = "Duração: ";
                    lblGenero8.Text = "Gênero: ";
                    txtFilme8.Text = objData[i + 7].titulo;
                    txtDuracao8.Text = objData[i + 7].duracao;
                    txtGenero8.Text = objData[i + 7].generoId.ToString();
                    txtLancamento8.Text = objData[i + 7].dataLancamento.ToString();
                    txtIdioma8.Text = objData[i + 7].idiomaOriginal;
                    txtDiretor8.Text = objData[i + 7].diretor.nome;
                    txtDescricao8.Text = objData[i + 7].descricao;

                    txtLancamento8.Visible = true;
                    lblLancamento8.Visible = true;
                    txtIdioma8.Visible = true;
                    lblIdioma8.Visible = true;
                    txtDiretor8.Visible = true;
                    lblDiretor8.Visible = true;
                    panel9.Visible = true;
                }
                else
                {
                    if ((i + 8) > objData.Count)
                    {
                        btnProxima.Enabled = false;
                    }
                    panel9.Hide();
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void carregarDiretor(List<DTO_Diretor> objData, int i, string inicio)
        {
            try
            {
                btnProxima.Enabled = true;
                if (inicio == "Inicio")
                {
                    btnAnterior.Enabled = false;
                }
                else
                {
                    btnAnterior.Enabled = true;

                }

                if (i < objData.Count)
                {
                    txtFilme1.Text = objData[i].nome;
                    lblGenero1.Text = "Nascimento: ";
                    txtGenero1.Text = objData[i].dataNasc;
                    lblDuracao1.Text = "Lista de Filmes: ";
                    //txtDuracao1.Text = objData[i].filmes.titulo;

                    txtLancamento1.Visible = false;
                    lblLancamento1.Visible = false;
                    txtIdioma1.Visible = false;
                    lblIdioma1.Visible = false;
                    txtDiretor1.Visible = false;
                    lblDiretor1.Visible = false;
                    txtDescricao1.Text = objData[i].bio;
                    panel2.Visible = true;

                }
                else
                {
                    panel3.Hide();
                    if ((i + 1) > objData.Count)
                    {
                        btnProxima.Enabled = false;
                    }
                }
                if ((i + 1) < objData.Count)
                {
                    txtFilme2.Text = objData[i+1].nome;
                    lblGenero2.Text = "Nascimento: ";
                    txtGenero2.Text = objData[i+1].dataNasc;
                    lblDuracao2.Text = "Lista de Filmes: ";
                    //txtDuracao2.Text = objData[i+1].filmes.titulo;

                    txtLancamento2.Visible = false;
                    lblLancamento2.Visible = false;
                    txtIdioma2.Visible = false;
                    lblIdioma2.Visible = false;
                    txtDiretor2.Visible = false;
                    lblDiretor2.Visible = false;
                    txtDescricao2.Text = objData[i+1].bio;
                    panel3.Visible = true;
                }
                else
                {
                    panel4.Hide();
                    if ((i + 2) > objData.Count)
                    {
                        btnProxima.Enabled = false;
                    }
                }
                if ((i + 2) < objData.Count)
                {
                    txtFilme3.Text = objData[i+2].nome;
                    lblGenero3.Text = "Nascimento: ";
                    txtGenero3.Text = objData[i+2].dataNasc;
                    lblDuracao3.Text = "Lista de Filmes: ";
                    //txtDuracao3.Text = objData[i+2].filmes.titulo;

                    txtLancamento3.Visible = false;
                    lblLancamento3.Visible = false;
                    txtIdioma3.Visible = false;
                    lblIdioma3.Visible = false;
                    txtDiretor3.Visible = false;
                    lblDiretor3.Visible = false;
                    txtDescricao3.Text = objData[i+2].bio;
                    panel4.Visible = true;
                }
                else
                {
                    panel5.Hide();
                    if ((i + 3) > objData.Count)
                    {
                        btnProxima.Enabled = false;
                    }
                }
                if ((i + 3) < objData.Count)
                {
                    txtFilme4.Text = objData[i+3].nome;
                    lblGenero4.Text = "Nascimento: ";
                    txtGenero4.Text = objData[i+3].dataNasc;
                    lblDuracao4.Text = "Lista de Filmes: ";
                   // txtDuracao4.Text = objData[i+3].filmes.titulo;

                    txtLancamento4.Visible = false;
                    lblLancamento4.Visible = false;
                    txtIdioma4.Visible = false;
                    lblIdioma4.Visible = false;
                    txtDiretor4.Visible = false;
                    lblDiretor4.Visible = false;
                    txtDescricao4.Text = objData[i+3].bio;
                    panel5.Visible = true;
                }
                else
                {
                    panel5.Hide();
                    if ((i + 4) > objData.Count)
                    {
                        btnProxima.Enabled = false;
                    }
                }
                if ((i + 4) < objData.Count)
                {
                    txtFilme5.Text = objData[i+4].nome;
                    lblGenero5.Text = "Nascimento: ";
                    txtGenero5.Text = objData[i+4].dataNasc;
                    lblDuracao5.Text = "Lista de Filmes: ";
                    //txtDuracao5.Text = objData[i+4].filmes.titulo;

                    txtLancamento5.Visible = false;
                    lblLancamento5.Visible = false;
                    txtIdioma5.Visible = false;
                    lblIdioma5.Visible = false;
                    txtDiretor5.Visible = false;
                    lblDiretor5.Visible = false;
                    txtDescricao5.Text = objData[i+4].bio;
                    panel6.Visible = true;
                }
                else
                {
                    if ((i + 5) > objData.Count)
                    {
                        btnProxima.Enabled = false;
                    }
                    panel6.Hide();
                }
                if ((i + 5) < objData.Count)
                {
                    txtFilme6.Text = objData[i+5].nome;
                    lblGenero6.Text = "Nascimento: ";
                    txtGenero6.Text = objData[i+5].dataNasc;
                    lblDuracao6.Text = "Lista de Filmes: ";
            //        txtDuracao6.Text = objData[i+5].filmes.titulo;

                    txtLancamento6.Visible = false;
                    lblLancamento6.Visible = false;
                    txtIdioma6.Visible = false;
                    lblIdioma6.Visible = false;
                    txtDiretor6.Visible = false;
                    lblDiretor6.Visible = false;
                    txtDescricao6.Text = objData[i+5].bio;
                    panel7.Visible = true;

                }
                else
                {
                    panel7.Hide();
                    if ((i + 6) > objData.Count)
                    {
                        btnProxima.Enabled = false;
                    }
                }
                if ((i + 6) < objData.Count)
                {
                    txtFilme7.Text = objData[i+6].nome;
                    lblGenero7.Text = "Nascimento: ";
                    txtGenero7.Text = objData[i+6].dataNasc;
                    lblDuracao7.Text = "Lista de Filmes: ";
               //     txtDuracao7.Text = objData[i+6].filmes.titulo;

                    txtLancamento7.Visible = false;
                    lblLancamento7.Visible = false;
                    txtIdioma7.Visible = false;
                    lblIdioma7.Visible = false;
                    txtDiretor7.Visible = false;
                    lblDiretor7.Visible = false;
                    txtDescricao7.Text = objData[i+6].bio;
                    panel8.Visible = true;

                }
                else
                {
                    panel8.Hide();
                    if ((i + 7) > objData.Count)
                    {
                        btnProxima.Enabled = false;
                    }
                }
                if ((i + 7) < objData.Count)
                {
                    txtFilme8.Text = objData[i+7].nome;
                    lblGenero8.Text = "Nascimento: ";
                    txtGenero8.Text = objData[i+7].dataNasc;
                    lblDuracao8.Text = "Lista de Filmes: ";
                //    txtDuracao8.Text = objData[i+7].filmes.titulo;

                    txtLancamento8.Visible = false;
                    lblLancamento8.Visible = false;
                    txtIdioma8.Visible = false;
                    lblIdioma8.Visible = false;
                    txtDiretor8.Visible = false;
                    lblDiretor8.Visible = false;
                    txtDescricao8.Text = objData[i+7].bio;
                    panel9.Visible = true;
                }
                else
                {
                    if ((i + 8) > objData.Count)
                    {
                        btnProxima.Enabled = false;
                    }
                    panel9.Hide();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public void carregarGenero(List<DTO_Filme> objData, int i, string inicio, string genero)
        {
            //try
            //{
            //    List<int> generos = new List<int>();
            //    btnProxima.Enabled = true;
            //    if (inicio == "Inicio")
            //    {
            //        btnAnterior.Enabled = false;
            //    }
            //    else
            //    {
            //        btnAnterior.Enabled = true;

            //    }
            //    var j = 0;
            //    while(j < objData.Count)
            //    {
            //        if(objData[j].genero.ToString() == genero)
            //        {
            //            ;// DTO_ListaGenero
            //        }
                    
            //        j++;
            //    }

            //    if (i < generos.Count)
            //    {


            //        lblDuracao1.Text = "Duração: ";
            //        lblGenero1.Text = "Gênero: ";
            //        txtFilme1.Text = dto[i].titulo;
            //        txtDuracao1.Text = objData[i].duracao;
            //        txtGenero1.Text = objData[i].generoId.ToString();
            //        txtLancamento1.Text = objData[i].dataLancamento.ToString();
            //        txtIdioma1.Text = objData[i].idiomaOriginal;
            //        txtDiretor1.Text = objData[i].diretor.nome;
            //        txtDescricao1.Text = objData[i].descricao;

            //        txtLancamento1.Visible = true;
            //        lblLancamento1.Visible = true;
            //        txtIdioma1.Visible = true;
            //        lblIdioma1.Visible = true;
            //        txtDiretor1.Visible = true;
            //        lblDiretor1.Visible = true;
            //        panel2.Visible = true;

            //    }
            //    else
            //    {
            //        panel3.Hide();
            //        if ((i + 1) > objData.Count)
            //        {
            //            btnProxima.Enabled = false;
            //        }
            //    }
            //    if ((i + 1) < objData.Count)
            //    {

            //        lblDuracao2.Text = "Duração: ";
            //        lblGenero2.Text = "Gênero: ";
            //        txtFilme2.Text = objData[i + 1].titulo;
            //        txtDuracao2.Text = objData[i + 1].duracao;
            //        txtGenero2.Text = objData[i + 1].generoId.ToString();
            //        txtLancamento2.Text = objData[i + 1].dataLancamento.ToString();
            //        txtIdioma2.Text = objData[i + 1].idiomaOriginal;
            //        txtDiretor2.Text = objData[i + 1].diretor.nome;
            //        txtDescricao2.Text = objData[i + 1].descricao;
            //        txtLancamento2.Visible = true;
            //        lblLancamento2.Visible = true;
            //        txtIdioma2.Visible = true;
            //        lblIdioma2.Visible = true;
            //        txtDiretor2.Visible = true;
            //        lblDiretor2.Visible = true;
            //        panel2.Visible = true;
            //    }
            //    else
            //    {
            //        panel4.Hide();
            //        if ((i + 2) > objData.Count)
            //        {
            //            btnProxima.Enabled = false;
            //        }
            //    }
            //    if ((i + 2) < objData.Count)
            //    {

            //        lblDuracao3.Text = "Duração: ";
            //        lblGenero3.Text = "Gênero: ";
            //        txtFilme3.Text = objData[i + 2].titulo;
            //        txtDuracao3.Text = objData[i + 2].duracao;
            //        txtGenero3.Text = objData[i + 2].generoId.ToString();
            //        txtLancamento3.Text = objData[i + 2].dataLancamento.ToString();
            //        txtIdioma3.Text = objData[i + 2].idiomaOriginal;
            //        txtDiretor3.Text = objData[i + 2].diretor.nome;
            //        txtDescricao3.Text = objData[i + 2].descricao;
            //        txtLancamento3.Visible = true;
            //        lblLancamento3.Visible = true;
            //        txtIdioma3.Visible = true;
            //        lblIdioma3.Visible = true;
            //        txtDiretor3.Visible = true;
            //        lblDiretor3.Visible = true;
            //        panel4.Visible = true;
            //    }
            //    else
            //    {
            //        panel5.Hide();
            //        if ((i + 3) > objData.Count)
            //        {
            //            btnProxima.Enabled = false;
            //        }
            //    }
            //    if ((i + 3) < objData.Count)
            //    {


            //        lblDuracao4.Text = "Duração: ";
            //        lblGenero4.Text = "Gênero: ";
            //        txtFilme4.Text = objData[i + 3].titulo;
            //        txtDuracao4.Text = objData[i + 3].duracao;
            //        txtGenero4.Text = objData[i + 3].generoId.ToString();
            //        txtLancamento4.Text = objData[i + 3].dataLancamento.ToString();
            //        txtIdioma4.Text = objData[i + 3].idiomaOriginal;
            //        txtDiretor4.Text = objData[i + 3].diretor.nome;
            //        txtDescricao4.Text = objData[i + 3].descricao;

            //        txtLancamento4.Visible = true;
            //        lblLancamento4.Visible = true;
            //        txtIdioma4.Visible = true;
            //        lblIdioma4.Visible = true;
            //        txtDiretor4.Visible = true;
            //        lblDiretor4.Visible = true;
            //        panel5.Visible = true;
            //    }
            //    else
            //    {
            //        panel5.Hide();
            //        if ((i + 4) > objData.Count)
            //        {
            //            btnProxima.Enabled = false;
            //        }
            //    }
            //    if ((i + 4) < objData.Count)
            //    {

            //        lblDuracao5.Text = "Duração: ";
            //        lblGenero5.Text = "Gênero: ";
            //        txtFilme5.Text = objData[i + 4].titulo;
            //        txtDuracao5.Text = objData[i + 4].duracao;
            //        txtGenero5.Text = objData[i + 4].generoId.ToString();
            //        txtLancamento5.Text = objData[i + 4].dataLancamento.ToString();
            //        txtIdioma5.Text = objData[i + 4].idiomaOriginal;
            //        txtDiretor5.Text = objData[i + 4].diretor.nome;
            //        txtDescricao5.Text = objData[i + 4].descricao;

            //        txtLancamento5.Visible = true;
            //        lblLancamento5.Visible = true;
            //        txtIdioma5.Visible = true;
            //        lblIdioma5.Visible = true;
            //        txtDiretor5.Visible = true;
            //        lblDiretor5.Visible = true;
            //        panel6.Visible = true;
            //    }
            //    else
            //    {
            //        if ((i + 5) > objData.Count)
            //        {
            //            btnProxima.Enabled = false;
            //        }
            //        panel6.Hide();
            //    }
            //    if ((i + 5) < objData.Count)
            //    {

            //        lblDuracao6.Text = "Duração: ";
            //        lblGenero6.Text = "Gênero: ";
            //        txtFilme6.Text = objData[i + 5].titulo;
            //        txtDuracao6.Text = objData[i + 5].duracao;
            //        txtGenero6.Text = objData[i + 5].generoId.ToString();
            //        txtLancamento6.Text = objData[i + 5].dataLancamento.ToString();
            //        txtIdioma6.Text = objData[i + 5].idiomaOriginal;
            //        txtDiretor6.Text = objData[i + 5].diretor.nome;
            //        txtDescricao6.Text = objData[i + 5].descricao;

            //        txtLancamento6.Visible = true;
            //        lblLancamento6.Visible = true;
            //        txtIdioma6.Visible = true;
            //        lblIdioma6.Visible = true;
            //        txtDiretor6.Visible = true;
            //        lblDiretor6.Visible = true;
            //        panel7.Visible = true;

            //    }
            //    else
            //    {
            //        panel7.Hide();
            //        if ((i + 6) > objData.Count)
            //        {
            //            btnProxima.Enabled = false;
            //        }
            //    }
            //    if ((i + 6) < objData.Count)
            //    {

            //        lblDuracao7.Text = "Duração: ";
            //        lblGenero7.Text = "Gênero: ";
            //        txtFilme7.Text = objData[i + 6].titulo;
            //        txtDuracao7.Text = objData[i + 6].duracao;
            //        txtGenero7.Text = objData[i + 6].generoId.ToString();
            //        txtLancamento7.Text = objData[i + 6].dataLancamento.ToString();
            //        txtIdioma7.Text = objData[i + 6].idiomaOriginal;
            //        txtDiretor7.Text = objData[i + 6].diretor.nome;
            //        txtDescricao7.Text = objData[i + 6].descricao;

            //        txtLancamento7.Visible = true;
            //        lblLancamento7.Visible = true;
            //        txtIdioma7.Visible = true;
            //        lblIdioma7.Visible = true;
            //        txtDiretor7.Visible = true;
            //        lblDiretor7.Visible = true;
            //        panel8.Visible = true;

            //    }
            //    else
            //    {
            //        panel8.Hide();
            //        if ((i + 7) > objData.Count)
            //        {
            //            btnProxima.Enabled = false;
            //        }
            //    }
            //    if ((i + 7) < objData.Count)
            //    {

            //        lblDuracao8.Text = "Duração: ";
            //        lblGenero8.Text = "Gênero: ";
            //        txtFilme8.Text = objData[i + 7].titulo;
            //        txtDuracao8.Text = objData[i + 7].duracao;
            //        txtGenero8.Text = objData[i + 7].generoId.ToString();
            //        txtLancamento8.Text = objData[i + 7].dataLancamento.ToString();
            //        txtIdioma8.Text = objData[i + 7].idiomaOriginal;
            //        txtDiretor8.Text = objData[i + 7].diretor.nome;
            //        txtDescricao8.Text = objData[i + 7].descricao;

            //        txtLancamento8.Visible = true;
            //        lblLancamento8.Visible = true;
            //        txtIdioma8.Visible = true;
            //        lblIdioma8.Visible = true;
            //        txtDiretor8.Visible = true;
            //        lblDiretor8.Visible = true;
            //        panel9.Visible = true;
            //    }
            //    else
            //    {
            //        if ((i + 8) > objData.Count)
            //        {
            //            btnProxima.Enabled = false;
            //        }
            //        panel9.Hide();
            //    }


            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void btnProxima_Click(object sender, EventArgs e)
        {
            try
            {
                m = m + 8;
                GetAllProdutos(m,"Meio");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            try
            {

                m = m - 8;
                if (m > 0)
                {
                    GetAllProdutos(m, "Meio");
                }
                else
                {
                    if (m == 0)
                    {
                        btnAnterior.Enabled = false;
                    }
                    btnProxima.Enabled = true;
                    GetAllProdutos(m, "Inicio");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                AddFilme addFilme = new AddFilme();

                addFilme.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "erro");
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {

                panel10.Height += 10;
                if (panel10.Size == panel10.MaximumSize )
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                panel10.Height -= 10;
                if (panel10.Size == panel10.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void btnGenero_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                GetAllDiretores(0, "Inicio");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GetAllProdutos(0, "Inicio");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnTerror_Click(object sender, EventArgs e)
        {
            try
            {
                // GetAllGeneroFilme(0, "Inicio","Terror");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
