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
        public List<DadosFilmes> filmeListTerror =  new List<DadosFilmes>();
        public List<DadosFilmes> filmeListComedia =  new List<DadosFilmes>();
        public List<DadosFilmes> filmeListDrama =  new List<DadosFilmes>();
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
                var m = 0;
                while (m < objData.Count)
                {
                    if (objData[m].genero.nome == "Terror")
                    {
                        var terror = new List<DadosFilmes>(){(new DadosFilmes{
                            titulo = objData[m].titulo,
                            duracao = objData[m].duracao,
                            genero = new Genero { nome = objData[m].genero.nome },
                            dataLancamento = objData[i].dataLancamento.ToString(),
                            idiomaOriginal = objData[i].idiomaOriginal,
                            diretor = new Diretor { nome = objData[m].diretor.nome },
                            descricao = objData[m].descricao
                        }) };
                        filmeListTerror.AddRange(terror);

                    }
                    else if (objData[m].genero.nome == "Comédia")
                    {
                        var comedia = new List<DadosFilmes>(){(new DadosFilmes{
                            titulo = objData[m].titulo,
                            duracao = objData[m].duracao,
                            genero = new Genero { nome = objData[m].genero.nome },
                            dataLancamento = objData[i].dataLancamento.ToString(),
                            idiomaOriginal = objData[i].idiomaOriginal,
                            diretor = new Diretor { nome = objData[m].diretor.nome },
                            descricao = objData[m].descricao
                        }) };

                        filmeListComedia.AddRange(comedia);
                    }
                    else if (objData[m].genero.nome == "Drama")
                    {
                        var Drama = new List<DadosFilmes>(){(new DadosFilmes{
                            titulo = objData[m].titulo,
                            duracao = objData[m].duracao,
                            genero = new Genero { nome = objData[m].genero.nome },
                            dataLancamento = objData[i].dataLancamento.ToString(),
                            idiomaOriginal = objData[i].idiomaOriginal,
                            diretor = new Diretor { nome = objData[m].diretor.nome },
                            descricao = objData[m].descricao
                        }) };

                        filmeListDrama.AddRange(Drama);
                    }
                    m++;
                }
                if (i < objData.Count)
                {

                    lblDuracao1.Text = "Duração: ";
                    lblGenero1.Text = "Gênero: ";
                    txtFilme1.Text = objData[i].titulo;
                    txtDuracao1.Text = objData[i].duracao;
                    txtGenero1.Text = objData[i].genero.nome;
                    txtLancamento1.Text = objData[i].dataLancamento.ToString();
                    txtIdioma1.Text = objData[i].idiomaOriginal;
                    txtDiretor1.Text = objData[i].diretor.nome;
                    txtDescricao1.Text = objData[i].descricao;
                    lblId1.Text = objData[i].id.ToString();
                    txtLancamento1.Visible = true;
                    lblLancamento1.Visible = true;
                    txtIdioma1.Visible = true;
                    lblIdioma1.Visible = true;
                    txtDiretor1.Visible = true;
                    lblDiretor1.Visible = true;
                    btnAtt1.Visible = true;
                    panel2.Visible = true;
                    lblSemFilme.Visible = false;

                }
                else
                {
                    if (objData.Count == 0)
                    {
                        panel2.Hide();
                        lblSemFilme.Visible = true;
                    }
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
                    lblId2.Text = objData[i+1].id.ToString();
                    txtFilme2.Text = objData[i + 1].titulo;
                    txtDuracao2.Text = objData[i + 1].duracao;
                    txtGenero2.Text = objData[i + 1].genero.nome;
                    txtLancamento2.Text = objData[i + 1].dataLancamento.ToString();
                    txtIdioma2.Text = objData[i + 1].idiomaOriginal;
                    txtDiretor2.Text = objData[i + 1].diretor.nome;
                    txtDescricao2.Text = objData[i + 1].descricao;

                    btnAtt2.Visible = true;
                    txtLancamento2.Visible = true;
                    lblLancamento2.Visible = true;
                    txtIdioma2.Visible = true;
                    lblIdioma2.Visible = true;
                    txtDiretor2.Visible = true;
                    lblDiretor2.Visible = true;
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

                    lblDuracao3.Text = "Duração: ";
                    lblGenero3.Text = "Gênero: "; 
                    lblId3.Text = objData[i+2].id.ToString();
                    txtFilme3.Text = objData[i + 2].titulo;
                    txtDuracao3.Text = objData[i + 2].duracao;
                    txtGenero3.Text = objData[i + 2].genero.nome;
                    txtLancamento3.Text = objData[i + 2].dataLancamento.ToString();
                    txtIdioma3.Text = objData[i + 2].idiomaOriginal;
                    txtDiretor3.Text = objData[i + 2].diretor.nome;
                    txtDescricao3.Text = objData[i + 2].descricao;

                    btnAtt3.Visible = true;
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
                    lblId4.Text = objData[i+3].id.ToString();
                    txtFilme4.Text = objData[i + 3].titulo;
                    txtDuracao4.Text = objData[i + 3].duracao;
                    txtGenero4.Text = objData[i + 3].genero.nome;
                    txtLancamento4.Text = objData[i + 3].dataLancamento.ToString();
                    txtIdioma4.Text = objData[i + 3].idiomaOriginal;
                    txtDiretor4.Text = objData[i + 3].diretor.nome;
                    txtDescricao4.Text = objData[i + 3].descricao;

                    btnAtt4.Visible = true;
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
                    lblId5.Text = objData[i+4].id.ToString();
                    txtFilme5.Text = objData[i + 4].titulo;
                    txtDuracao5.Text = objData[i + 4].duracao;
                    txtGenero5.Text = objData[i + 4].genero.nome;
                    txtLancamento5.Text = objData[i + 4].dataLancamento.ToString();
                    txtIdioma5.Text = objData[i + 4].idiomaOriginal;
                    txtDiretor5.Text = objData[i + 4].diretor.nome;
                    txtDescricao5.Text = objData[i + 4].descricao;

                    btnAtt5.Visible = true;
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
                    lblId6.Text = objData[i+5].id.ToString();
                    txtFilme6.Text = objData[i + 5].titulo;
                    txtDuracao6.Text = objData[i + 5].duracao;
                    txtGenero6.Text = objData[i + 5].genero.nome;
                    txtLancamento6.Text = objData[i + 5].dataLancamento.ToString();
                    txtIdioma6.Text = objData[i + 5].idiomaOriginal;
                    txtDiretor6.Text = objData[i + 5].diretor.nome;
                    txtDescricao6.Text = objData[i + 5].descricao;

                    btnAtt6.Visible = true;
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
                    lblId7.Text = objData[i+6].id.ToString();
                    txtFilme7.Text = objData[i + 6].titulo;
                    txtDuracao7.Text = objData[i + 6].duracao;
                    txtGenero7.Text = objData[i + 6].genero.nome;
                    txtLancamento7.Text = objData[i + 6].dataLancamento.ToString();
                    txtIdioma7.Text = objData[i + 6].idiomaOriginal;
                    txtDiretor7.Text = objData[i + 6].diretor.nome;
                    txtDescricao7.Text = objData[i + 6].descricao;

                    btnAtt7.Visible = true;
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
                    lblId8.Text = objData[i+7].id.ToString();
                    txtFilme8.Text = objData[i + 7].titulo;
                    txtDuracao8.Text = objData[i + 7].duracao;
                    txtGenero8.Text = objData[i + 7].genero.nome;
                    txtLancamento8.Text = objData[i + 7].dataLancamento.ToString();
                    txtIdioma8.Text = objData[i + 7].idiomaOriginal;
                    txtDiretor8.Text = objData[i + 7].diretor.nome;
                    txtDescricao8.Text = objData[i + 7].descricao;

                    btnAtt8.Visible = true;
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
                    btnAtt1.Visible = false;
                    lblSemFilme.Visible = false;
                }
                else
                {

                    if (objData.Count == 0)
                    {
                        panel2.Hide();
                        lblSemFilme.Visible = true;
                    }
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
                    btnAtt2.Visible = false;
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
                    btnAtt3.Visible = false;
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
                    btnAtt4.Visible = false;
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
                    btnAtt5.Visible = false;
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
                    btnAtt6.Visible = false;
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
                    btnAtt7.Visible = false;
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
                    btnAtt8.Visible = false;
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

        public void carregarGenero(string inicio, string genero)
        {
            try
            {
                List<int> generos = new List<int>();
                btnProxima.Enabled = true;
                if (inicio == "Inicio")
                {
                    btnAnterior.Enabled = false;
                }
                else
                {
                    btnAnterior.Enabled = true;

                }
                int i = 0;
                if(genero == "Terror" )
                {

                    if (filmeListTerror.Count> i && filmeListTerror.Count > 0)
                    {


                        lblDuracao1.Text = "Duração: ";
                        lblGenero1.Text = "Gênero: ";
                        txtFilme1.Text = filmeListTerror[i].titulo;
                        txtDuracao1.Text = filmeListTerror[i].duracao;
                        txtGenero1.Text = filmeListTerror[i].genero.nome;
                        txtLancamento1.Text = filmeListTerror[i].dataLancamento.ToString();
                        txtIdioma1.Text = filmeListTerror[i].idiomaOriginal;
                        txtDiretor1.Text = filmeListTerror[i].diretor.nome;
                        txtDescricao1.Text = filmeListTerror[i].descricao;

                        txtLancamento1.Visible = true;
                        lblLancamento1.Visible = true;
                        txtIdioma1.Visible = true;
                        lblIdioma1.Visible = true;
                        txtDiretor1.Visible = true;
                        lblDiretor1.Visible = true;
                        panel2.Visible = true;
                        lblSemFilme.Visible = false;
                    }
                    else
                    {
                        if(filmeListTerror.Count == 0)
                        {
                            panel2.Hide();
                            lblSemFilme.Visible = true;
                        }
                        panel3.Hide();
                        if ((i + 1) > filmeListTerror.Count)
                        {
                            btnProxima.Enabled = false;
                        }
                    }
                    if ((i + 1) < filmeListTerror.Count)
                    {

                        lblDuracao2.Text = "Duração: ";
                        lblGenero2.Text = "Gênero: ";
                        txtFilme2.Text = filmeListTerror[i + 1].titulo;
                        txtDuracao2.Text = filmeListTerror[i + 1].duracao;
                        txtGenero2.Text = filmeListTerror[i + 1].genero.nome;
                        txtLancamento2.Text = filmeListTerror[i + 1].dataLancamento.ToString();
                        txtIdioma2.Text = filmeListTerror[i + 1].idiomaOriginal;
                        txtDiretor2.Text = filmeListTerror[i + 1].diretor.nome;
                        txtDescricao2.Text = filmeListTerror[i + 1].descricao;
                        txtLancamento2.Visible = true;
                        lblLancamento2.Visible = true;
                        txtIdioma2.Visible = true;
                        lblIdioma2.Visible = true;
                        txtDiretor2.Visible = true;
                        lblDiretor2.Visible = true;
                        panel3.Visible = true;
                    }
                    else
                    {
                        panel4.Hide();
                        if ((i + 2) > filmeListTerror.Count)
                        {
                            btnProxima.Enabled = false;
                        }
                    }
                    if ((i + 2) < filmeListTerror.Count)
                    {

                        lblDuracao3.Text = "Duração: ";
                        lblGenero3.Text = "Gênero: ";
                        txtFilme3.Text = filmeListTerror[i + 2].titulo;
                        txtDuracao3.Text = filmeListTerror[i + 2].duracao;
                        txtGenero3.Text = filmeListTerror[i + 2].genero.nome;
                        txtLancamento3.Text = filmeListTerror[i + 2].dataLancamento.ToString();
                        txtIdioma3.Text = filmeListTerror[i + 2].idiomaOriginal;
                        txtDiretor3.Text = filmeListTerror[i + 2].diretor.nome;
                        txtDescricao3.Text = filmeListTerror[i + 2].descricao;
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
                        if ((i + 3) > filmeListTerror.Count)
                        {
                            btnProxima.Enabled = false;
                        }
                    }
                    if ((i + 3) < filmeListTerror.Count)
                    {


                        lblDuracao4.Text = "Duração: ";
                        lblGenero4.Text = "Gênero: ";
                        txtFilme4.Text = filmeListTerror[i + 3].titulo;
                        txtDuracao4.Text = filmeListTerror[i + 3].duracao;
                        txtGenero4.Text = filmeListTerror[i + 3].genero.nome;
                        txtLancamento4.Text = filmeListTerror[i + 3].dataLancamento.ToString();
                        txtIdioma4.Text = filmeListTerror[i + 3].idiomaOriginal;
                        txtDiretor4.Text = filmeListTerror[i + 3].diretor.nome;
                        txtDescricao4.Text = filmeListTerror[i + 3].descricao;

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
                        if ((i + 4) > filmeListTerror.Count)
                        {
                            btnProxima.Enabled = false;
                        }
                    }
                    if ((i + 4) < filmeListTerror.Count)
                    {

                        lblDuracao5.Text = "Duração: ";
                        lblGenero5.Text = "Gênero: ";
                        txtFilme5.Text = filmeListTerror[i + 4].titulo;
                        txtDuracao5.Text = filmeListTerror[i + 4].duracao;
                        txtGenero5.Text = filmeListTerror[i + 4].genero.nome;
                        txtLancamento5.Text = filmeListTerror[i + 4].dataLancamento.ToString();
                        txtIdioma5.Text = filmeListTerror[i + 4].idiomaOriginal;
                        txtDiretor5.Text = filmeListTerror[i + 4].diretor.nome;
                        txtDescricao5.Text = filmeListTerror[i + 4].descricao;

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
                        if ((i + 5) > filmeListTerror.Count)
                        {
                            btnProxima.Enabled = false;
                        }
                        panel6.Hide();
                    }
                    if ((i + 5) < filmeListTerror.Count)
                    {

                        lblDuracao6.Text = "Duração: ";
                        lblGenero6.Text = "Gênero: ";
                        txtFilme6.Text = filmeListTerror[i + 5].titulo;
                        txtDuracao6.Text = filmeListTerror[i + 5].duracao;
                        txtGenero6.Text = filmeListTerror[i + 5].genero.nome;
                        txtLancamento6.Text = filmeListTerror[i + 5].dataLancamento.ToString();
                        txtIdioma6.Text = filmeListTerror[i + 5].idiomaOriginal;
                        txtDiretor6.Text = filmeListTerror[i + 5].diretor.nome;
                        txtDescricao6.Text = filmeListTerror[i + 5].descricao;

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
                        if ((i + 6) > filmeListTerror.Count)
                        {
                            btnProxima.Enabled = false;
                        }
                    }
                    if ((i + 6) < filmeListTerror.Count)
                    {

                        lblDuracao7.Text = "Duração: ";
                        lblGenero7.Text = "Gênero: ";
                        txtFilme7.Text = filmeListTerror[i + 6].titulo;
                        txtDuracao7.Text = filmeListTerror[i + 6].duracao;
                        txtGenero7.Text = filmeListTerror[i + 6].genero.nome;
                        txtLancamento7.Text = filmeListTerror[i + 6].dataLancamento.ToString();
                        txtIdioma7.Text = filmeListTerror[i + 6].idiomaOriginal;
                        txtDiretor7.Text = filmeListTerror[i + 6].diretor.nome;
                        txtDescricao7.Text = filmeListTerror[i + 6].descricao;

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
                        if ((i + 7) > filmeListTerror.Count)
                        {
                            btnProxima.Enabled = false;
                        }
                    }
                    if ((i + 7) < filmeListTerror.Count)
                    {

                        lblDuracao8.Text = "Duração: ";
                        lblGenero8.Text = "Gênero: ";
                        txtFilme8.Text = filmeListTerror[i + 7].titulo;
                        txtDuracao8.Text = filmeListTerror[i + 7].duracao;
                        txtGenero8.Text = filmeListTerror[i + 7].genero.nome;
                        txtLancamento8.Text = filmeListTerror[i + 7].dataLancamento.ToString();
                        txtIdioma8.Text = filmeListTerror[i + 7].idiomaOriginal;
                        txtDiretor8.Text = filmeListTerror[i + 7].diretor.nome;
                        txtDescricao8.Text = filmeListTerror[i + 7].descricao;

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
                        if ((i + 8) > filmeListTerror.Count)
                        {
                            btnProxima.Enabled = false;
                        }
                        panel9.Hide();
                    }


                }
                if (genero == "Drama")
                {

                    if (filmeListDrama.Count > i && filmeListDrama.Count > 0)
                    {


                        lblDuracao1.Text = "Duração: ";
                        lblGenero1.Text = "Gênero: ";
                        txtFilme1.Text = filmeListDrama[i].titulo;
                        txtDuracao1.Text = filmeListDrama[i].duracao;
                        txtGenero1.Text = filmeListDrama[i].genero.nome;
                        txtLancamento1.Text = filmeListDrama[i].dataLancamento.ToString();
                        txtIdioma1.Text = filmeListDrama[i].idiomaOriginal;
                        txtDiretor1.Text = filmeListDrama[i].diretor.nome;
                        txtDescricao1.Text = filmeListDrama[i].descricao;

                        txtLancamento1.Visible = true;
                        lblLancamento1.Visible = true;
                        txtIdioma1.Visible = true;
                        lblIdioma1.Visible = true;
                        txtDiretor1.Visible = true;
                        lblDiretor1.Visible = true;
                        panel2.Visible = true;
                        lblSemFilme.Visible = false;
                    }
                    else
                    {
                        if (filmeListDrama.Count == 0)
                        {
                            panel2.Hide();
                            lblSemFilme.Visible = true;
                        }
                        panel3.Hide();
                        if ((i + 1) > filmeListDrama.Count)
                        {
                            btnProxima.Enabled = false;
                        }
                    }
                    if ((i + 1) < filmeListDrama.Count)
                    {

                        lblDuracao2.Text = "Duração: ";
                        lblGenero2.Text = "Gênero: ";
                        txtFilme2.Text = filmeListDrama[i + 1].titulo;
                        txtDuracao2.Text = filmeListDrama[i + 1].duracao;
                        txtGenero2.Text = filmeListDrama[i + 1].genero.nome;
                        txtLancamento2.Text = filmeListDrama[i + 1].dataLancamento.ToString();
                        txtIdioma2.Text = filmeListDrama[i + 1].idiomaOriginal;
                        txtDiretor2.Text = filmeListDrama[i + 1].diretor.nome;
                        txtDescricao2.Text = filmeListDrama[i + 1].descricao;
                        txtLancamento2.Visible = true;
                        lblLancamento2.Visible = true;
                        txtIdioma2.Visible = true;
                        lblIdioma2.Visible = true;
                        txtDiretor2.Visible = true;
                        lblDiretor2.Visible = true;
                        panel3.Visible = true;
                    }
                    else
                    {
                        panel4.Hide();
                        if ((i + 2) > filmeListDrama.Count)
                        {
                            btnProxima.Enabled = false;
                        }
                    }
                    if ((i + 2) < filmeListDrama.Count)
                    {

                        lblDuracao3.Text = "Duração: ";
                        lblGenero3.Text = "Gênero: ";
                        txtFilme3.Text = filmeListDrama[i + 2].titulo;
                        txtDuracao3.Text = filmeListDrama[i + 2].duracao;
                        txtGenero3.Text = filmeListDrama[i + 2].genero.nome;
                        txtLancamento3.Text = filmeListDrama[i + 2].dataLancamento.ToString();
                        txtIdioma3.Text = filmeListDrama[i + 2].idiomaOriginal;
                        txtDiretor3.Text = filmeListDrama[i + 2].diretor.nome;
                        txtDescricao3.Text = filmeListDrama[i + 2].descricao;
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
                        if ((i + 3) > filmeListDrama.Count)
                        {
                            btnProxima.Enabled = false;
                        }
                    }
                    if ((i + 3) < filmeListDrama.Count)
                    {


                        lblDuracao4.Text = "Duração: ";
                        lblGenero4.Text = "Gênero: ";
                        txtFilme4.Text = filmeListDrama[i + 3].titulo;
                        txtDuracao4.Text = filmeListDrama[i + 3].duracao;
                        txtGenero4.Text = filmeListDrama[i + 3].genero.nome;
                        txtLancamento4.Text = filmeListDrama[i + 3].dataLancamento.ToString();
                        txtIdioma4.Text = filmeListDrama[i + 3].idiomaOriginal;
                        txtDiretor4.Text = filmeListDrama[i + 3].diretor.nome;
                        txtDescricao4.Text = filmeListDrama[i + 3].descricao;

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
                        if ((i + 4) > filmeListDrama.Count)
                        {
                            btnProxima.Enabled = false;
                        }
                    }
                    if ((i + 4) < filmeListDrama.Count)
                    {

                        lblDuracao5.Text = "Duração: ";
                        lblGenero5.Text = "Gênero: ";
                        txtFilme5.Text = filmeListDrama[i + 4].titulo;
                        txtDuracao5.Text = filmeListDrama[i + 4].duracao;
                        txtGenero5.Text = filmeListDrama[i + 4].genero.nome;
                        txtLancamento5.Text = filmeListDrama[i + 4].dataLancamento.ToString();
                        txtIdioma5.Text = filmeListDrama[i + 4].idiomaOriginal;
                        txtDiretor5.Text = filmeListDrama[i + 4].diretor.nome;
                        txtDescricao5.Text = filmeListDrama[i + 4].descricao;

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
                        if ((i + 5) > filmeListDrama.Count)
                        {
                            btnProxima.Enabled = false;
                        }
                        panel6.Hide();
                    }
                    if ((i + 5) < filmeListDrama.Count)
                    {

                        lblDuracao6.Text = "Duração: ";
                        lblGenero6.Text = "Gênero: ";
                        txtFilme6.Text = filmeListDrama[i + 5].titulo;
                        txtDuracao6.Text = filmeListDrama[i + 5].duracao;
                        txtGenero6.Text = filmeListDrama[i + 5].genero.nome;
                        txtLancamento6.Text = filmeListDrama[i + 5].dataLancamento.ToString();
                        txtIdioma6.Text = filmeListDrama[i + 5].idiomaOriginal;
                        txtDiretor6.Text = filmeListDrama[i + 5].diretor.nome;
                        txtDescricao6.Text = filmeListDrama[i + 5].descricao;

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
                        if ((i + 6) > filmeListDrama.Count)
                        {
                            btnProxima.Enabled = false;
                        }
                    }
                    if ((i + 6) < filmeListDrama.Count)
                    {

                        lblDuracao7.Text = "Duração: ";
                        lblGenero7.Text = "Gênero: ";
                        txtFilme7.Text = filmeListDrama[i + 6].titulo;
                        txtDuracao7.Text = filmeListDrama[i + 6].duracao;
                        txtGenero7.Text = filmeListDrama[i + 6].genero.nome;
                        txtLancamento7.Text = filmeListDrama[i + 6].dataLancamento.ToString();
                        txtIdioma7.Text = filmeListDrama[i + 6].idiomaOriginal;
                        txtDiretor7.Text = filmeListDrama[i + 6].diretor.nome;
                        txtDescricao7.Text = filmeListDrama[i + 6].descricao;

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
                        if ((i + 7) > filmeListDrama.Count)
                        {
                            btnProxima.Enabled = false;
                        }
                    }
                    if ((i + 7) < filmeListDrama.Count)
                    {

                        lblDuracao8.Text = "Duração: ";
                        lblGenero8.Text = "Gênero: ";
                        txtFilme8.Text = filmeListDrama[i + 7].titulo;
                        txtDuracao8.Text = filmeListDrama[i + 7].duracao;
                        txtGenero8.Text = filmeListDrama[i + 7].genero.nome;
                        txtLancamento8.Text = filmeListDrama[i + 7].dataLancamento.ToString();
                        txtIdioma8.Text = filmeListDrama[i + 7].idiomaOriginal;
                        txtDiretor8.Text = filmeListDrama[i + 7].diretor.nome;
                        txtDescricao8.Text = filmeListDrama[i + 7].descricao;

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
                        if ((i + 8) > filmeListDrama.Count)
                        {
                            btnProxima.Enabled = false;
                        }
                        panel9.Hide();
                    }


                
            }
                if (genero == "Comédia")
                {

                    {

                        if (filmeListComedia.Count > i && filmeListComedia.Count > 0)
                        {


                            lblDuracao1.Text = "Duração: ";
                            lblGenero1.Text = "Gênero: ";
                            txtFilme1.Text = filmeListComedia[i].titulo;
                            txtDuracao1.Text = filmeListComedia[i].duracao;
                            txtGenero1.Text = filmeListComedia[i].genero.nome;
                            txtLancamento1.Text = filmeListComedia[i].dataLancamento.ToString();
                            txtIdioma1.Text = filmeListComedia[i].idiomaOriginal;
                            txtDiretor1.Text = filmeListComedia[i].diretor.nome;
                            txtDescricao1.Text = filmeListComedia[i].descricao;

                            txtLancamento1.Visible = true;
                            lblLancamento1.Visible = true;
                            txtIdioma1.Visible = true;
                            lblIdioma1.Visible = true;
                            txtDiretor1.Visible = true;
                            lblDiretor1.Visible = true;
                            panel2.Visible = true;
                            lblSemFilme.Visible = false;
                        }
                        else
                        {
                            if (filmeListComedia.Count == 0)
                            {
                                panel2.Hide();
                                lblSemFilme.Visible = true;
                            }
                            panel3.Hide();
                            if ((i + 1) > filmeListComedia.Count)
                            {
                                btnProxima.Enabled = false;
                            }
                        }
                        if ((i + 1) < filmeListComedia.Count)
                        {

                            lblDuracao2.Text = "Duração: ";
                            lblGenero2.Text = "Gênero: ";
                            txtFilme2.Text = filmeListComedia[i + 1].titulo;
                            txtDuracao2.Text = filmeListComedia[i + 1].duracao;
                            txtGenero2.Text = filmeListComedia[i + 1].genero.nome;
                            txtLancamento2.Text = filmeListComedia[i + 1].dataLancamento.ToString();
                            txtIdioma2.Text = filmeListComedia[i + 1].idiomaOriginal;
                            txtDiretor2.Text = filmeListComedia[i + 1].diretor.nome;
                            txtDescricao2.Text = filmeListComedia[i + 1].descricao;
                            txtLancamento2.Visible = true;
                            lblLancamento2.Visible = true;
                            txtIdioma2.Visible = true;
                            lblIdioma2.Visible = true;
                            txtDiretor2.Visible = true;
                            lblDiretor2.Visible = true;
                            panel3.Visible = true;
                        }
                        else
                        {
                            panel4.Hide();
                            if ((i + 2) > filmeListComedia.Count)
                            {
                                btnProxima.Enabled = false;
                            }
                        }
                        if ((i + 2) < filmeListComedia.Count)
                        {

                            lblDuracao3.Text = "Duração: ";
                            lblGenero3.Text = "Gênero: ";
                            txtFilme3.Text = filmeListComedia[i + 2].titulo;
                            txtDuracao3.Text = filmeListComedia[i + 2].duracao;
                            txtGenero3.Text = filmeListComedia[i + 2].genero.nome;
                            txtLancamento3.Text = filmeListComedia[i + 2].dataLancamento.ToString();
                            txtIdioma3.Text = filmeListComedia[i + 2].idiomaOriginal;
                            txtDiretor3.Text = filmeListComedia[i + 2].diretor.nome;
                            txtDescricao3.Text = filmeListComedia[i + 2].descricao;
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
                            if ((i + 3) > filmeListComedia.Count)
                            {
                                btnProxima.Enabled = false;
                            }
                        }
                        if ((i + 3) < filmeListComedia.Count)
                        {


                            lblDuracao4.Text = "Duração: ";
                            lblGenero4.Text = "Gênero: ";
                            txtFilme4.Text = filmeListComedia[i + 3].titulo;
                            txtDuracao4.Text = filmeListComedia[i + 3].duracao;
                            txtGenero4.Text = filmeListComedia[i + 3].genero.nome;
                            txtLancamento4.Text = filmeListComedia[i + 3].dataLancamento.ToString();
                            txtIdioma4.Text = filmeListComedia[i + 3].idiomaOriginal;
                            txtDiretor4.Text = filmeListComedia[i + 3].diretor.nome;
                            txtDescricao4.Text = filmeListComedia[i + 3].descricao;

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
                            if ((i + 4) > filmeListComedia.Count)
                            {
                                btnProxima.Enabled = false;
                            }
                        }
                        if ((i + 4) < filmeListComedia.Count)
                        {

                            lblDuracao5.Text = "Duração: ";
                            lblGenero5.Text = "Gênero: ";
                            txtFilme5.Text = filmeListComedia[i + 4].titulo;
                            txtDuracao5.Text = filmeListComedia[i + 4].duracao;
                            txtGenero5.Text = filmeListComedia[i + 4].genero.nome;
                            txtLancamento5.Text = filmeListComedia[i + 4].dataLancamento.ToString();
                            txtIdioma5.Text = filmeListComedia[i + 4].idiomaOriginal;
                            txtDiretor5.Text = filmeListComedia[i + 4].diretor.nome;
                            txtDescricao5.Text = filmeListComedia[i + 4].descricao;

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
                            if ((i + 5) > filmeListComedia.Count)
                            {
                                btnProxima.Enabled = false;
                            }
                            panel6.Hide();
                        }
                        if ((i + 5) < filmeListComedia.Count)
                        {

                            lblDuracao6.Text = "Duração: ";
                            lblGenero6.Text = "Gênero: ";
                            txtFilme6.Text = filmeListComedia[i + 5].titulo;
                            txtDuracao6.Text = filmeListComedia[i + 5].duracao;
                            txtGenero6.Text = filmeListComedia[i + 5].genero.nome;
                            txtLancamento6.Text = filmeListComedia[i + 5].dataLancamento.ToString();
                            txtIdioma6.Text = filmeListComedia[i + 5].idiomaOriginal;
                            txtDiretor6.Text = filmeListComedia[i + 5].diretor.nome;
                            txtDescricao6.Text = filmeListComedia[i + 5].descricao;

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
                            if ((i + 6) > filmeListComedia.Count)
                            {
                                btnProxima.Enabled = false;
                            }
                        }
                        if ((i + 6) < filmeListComedia.Count)
                        {

                            lblDuracao7.Text = "Duração: ";
                            lblGenero7.Text = "Gênero: ";
                            txtFilme7.Text = filmeListComedia[i + 6].titulo;
                            txtDuracao7.Text = filmeListComedia[i + 6].duracao;
                            txtGenero7.Text = filmeListComedia[i + 6].genero.nome;
                            txtLancamento7.Text = filmeListComedia[i + 6].dataLancamento.ToString();
                            txtIdioma7.Text = filmeListComedia[i + 6].idiomaOriginal;
                            txtDiretor7.Text = filmeListComedia[i + 6].diretor.nome;
                            txtDescricao7.Text = filmeListComedia[i + 6].descricao;

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
                            if ((i + 7) > filmeListComedia.Count)
                            {
                                btnProxima.Enabled = false;
                            }
                        }
                        if ((i + 7) < filmeListComedia.Count)
                        {

                            lblDuracao8.Text = "Duração: ";
                            lblGenero8.Text = "Gênero: ";
                            txtFilme8.Text = filmeListComedia[i + 7].titulo;
                            txtDuracao8.Text = filmeListComedia[i + 7].duracao;
                            txtGenero8.Text = filmeListComedia[i + 7].genero.nome;
                            txtLancamento8.Text = filmeListComedia[i + 7].dataLancamento.ToString();
                            txtIdioma8.Text = filmeListComedia[i + 7].idiomaOriginal;
                            txtDiretor8.Text = filmeListComedia[i + 7].diretor.nome;
                            txtDescricao8.Text = filmeListComedia[i + 7].descricao;

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
                            if ((i + 8) > filmeListComedia.Count)
                            {
                                btnProxima.Enabled = false;
                            }
                            panel9.Hide();
                        }



                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
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
                AddFilme addFilme = new AddFilme("Incluir", -1);

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

       

        private void btnAtt1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(lblId1.Text);
                AddFilme add = new AddFilme("Atualizar", id);
                add.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAtt2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId2.Text);
            AddFilme add = new AddFilme("Atualizar", id);
            add.Show();
        }

        private void btnAtt3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId3.Text);
            AddFilme add = new AddFilme("Atualizar", id);
            add.Show();
        }

        private void btnAtt4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId4.Text);
            AddFilme add = new AddFilme("Atualizar", id);
            add.Show();
        }

        private void btnAtt5_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId5.Text);
            AddFilme add = new AddFilme("Atualizar", id);
            add.Show();
        }

        private void btnAtt6_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId6.Text);
            AddFilme add = new AddFilme("Atualizar", id);
            add.Show();
        }

        private void btnAtt7_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId7.Text);
            AddFilme add = new AddFilme("Atualizar", id);
            add.Show();
        }

        private void btnAtt8_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblId8.Text);
            AddFilme add = new AddFilme("Atualizar", id);
            add.Show();
        }

        private void btnDrama_Click(object sender, EventArgs e)
        {
            try
            {
                carregarGenero("Inicio", "Drama");
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnTerror_Click(object sender, EventArgs e)
        {
            try
            {
                carregarGenero("Inicio", "Terror");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnComedia_Click(object sender, EventArgs e)
        {
            try
            {
                carregarGenero("Inicio", "Comédia");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
