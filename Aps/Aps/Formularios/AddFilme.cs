using Aps.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace Aps.Formularios
{

    public partial class AddFilme : Form
    {
        public string forMetodo;
        public int forID;
        public AddFilme(string metodo,int id)
        {
            forMetodo = metodo;
            forID = id;
            InitializeComponent();
        }

        private async void InserirFilmes(DTO_Filme dto)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync("http://localhost:5000/CatalogoFilmesAPI/filme/"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            

                            var serializedProduto = JsonConvert.SerializeObject(dto);
                            var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                            var result = await client.PostAsync("http://localhost:5000/CatalogoFilmesAPI/filme/", content);

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
                throw ex;
            }
        }
        private async void AtualizarFilmes(DTO_Filme dto)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync("http://localhost:5000/CatalogoFilmesAPI/filme/"))
                    {
                        if (response.IsSuccessStatusCode)
                        {


                            var serializedProduto = JsonConvert.SerializeObject(dto);
                            var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");
                            var result = await client.PutAsync("http://localhost:5000/CatalogoFilmesAPI/filme/"+forID+"", content);

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
                throw ex;
            }
        }

        private void AddFilme_Load(object sender, EventArgs e)
        {
            try
            {
                if(forMetodo == "Incluir")
                {
                    GetAllProdutos();
                    GetAllGenero();
                }
                else
                {
                    lblIdFilme.Text = forMetodo;
                    GetAllAtt();
                    GetAllProdutos();
                    GetAllGenero();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void AtualizarCampos()
        {
            try
            {
                lblIdFilme.Text = forMetodo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private async void GetAllGenero()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync("http://localhost:5000/CatalogoFilmesAPI/genero/"))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            TelaIncial form = new TelaIncial();

                            var ProdutoJsonString = await response.Content.ReadAsStringAsync();

                            var objGenero = JsonConvert.DeserializeObject<List<Genero>>(ProdutoJsonString);

                            List<string> genero = new List<string>();
                            
                            var i = 0;
                            while (objGenero.Count > i)
                            {
                                if (objGenero[i].nome != null)
                                {

                                    genero.AddRange(new string[] { objGenero[i].nome });
                                }
                                i++;
                            }
                            List<string> lista = new List<string>();
                            lista.AddRange(genero.Distinct());
                            cmbGenero.DataSource = lista;


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

                throw ex;
            }
        }

        private async void GetAllProdutos()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync("http://localhost:5000/CatalogoFilmesAPI/diretor/"))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            TelaIncial form = new TelaIncial();

                            var ProdutoJsonString = await response.Content.ReadAsStringAsync();

                            var objData = JsonConvert.DeserializeObject<List<Diretor>>(ProdutoJsonString);
                            var i = 0;
                            // lista de nome do diretor

                            List<string> diretor  = new List<string>();

                            while (objData.Count > i)
                            {
                                if (objData[i].nome != null)
                                {
                                    diretor.AddRange(new string[] { objData[i].nome });
                                }
                                i++;
                            }
                            List<string> lista = new List<string>();
                            lista.AddRange(diretor.Distinct());
                            cmbDiretor.DataSource = lista;



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

                throw ex;
            }
        }
        private async void GetAllAtt()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync("http://localhost:5000/CatalogoFilmesAPI/filme/"))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            TelaIncial form = new TelaIncial();

                            var ProdutoJsonString = await response.Content.ReadAsStringAsync();

                            var objData = JsonConvert.DeserializeObject<List<DTO_Filme>>(ProdutoJsonString);
                            int i = 0;
                            // lista de nome do diretor
                            while(i < objData.Count)
                            {
                                if(objData[i].id == forID)
                                {
                                    txtNomeFilme.Text = objData[i].titulo;
                                    TxtIdioma.Text = objData[i].idiomaOriginal;
                                    txtDtLancamento.Text = objData[i].dataLancamento;
                                    txtDuracao.Text = objData[i].duracao;
                                    cmbGenero.SelectedItem = objData[i].genero;
                                    cmbDiretor.SelectedItem = objData[i].diretor;
                                    TxtDescricao.Text = objData[i].descricao;
                                }
                                i++;
                            }

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

                throw ex;
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNomeFilme.Text == "")
                {
                    MessageBox.Show("ESCREVA NOME DO FILME");
                }

                else if (txtDtLancamento.Text == "")
                {
                    MessageBox.Show("ESCREVA A DATA DE LANÇAMENTO");
                }

                else if (TxtDescricao.Text == "")
                {
                    MessageBox.Show("ESCREVA A DESCRIÇÃO");
                }

                else if (txtDuracao.Text == "")
                {
                    MessageBox.Show("ESCREVA A DURAÇÃO");
                }

                else if (TxtIdioma.Text == "")
                {
                    MessageBox.Show("ESCREVA O IDIOMA");
                }

                else
                {
                    if (forID == -1)
                    {
                        DTO_Filme dto = new DTO_Filme()
                        {
                            titulo = txtNomeFilme.Text,
                            descricao = TxtDescricao.Text,
                            idiomaOriginal = TxtIdioma.Text,
                            dataLancamento = txtDtLancamento.Text,
                            duracao = txtDuracao.Text,
                            genero = new Genero { nome = cmbGenero.Text },
                            diretor = new Diretor { nome = cmbDiretor.Text }
                        };
                        InserirFilmes(dto);
                        MessageBox.Show("Adicionado com Sucesso!!");
                    }
                    else
                    {

                        DTO_Filme dto = new DTO_Filme()
                        {
                            id = forID,
                            titulo = txtNomeFilme.Text,
                            descricao = TxtDescricao.Text,
                            idiomaOriginal = TxtIdioma.Text,
                            dataLancamento = txtDtLancamento.Text,
                            duracao = txtDuracao.Text,
                            genero = new Genero { nome = cmbGenero.Text },
                            diretor = new Diretor { nome = cmbDiretor.Text }
                        };
                        AtualizarFilmes(dto);
                        MessageBox.Show("Atualizado com Sucesso!!");
                    }

                }
                this.Close();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
