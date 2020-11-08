using Aps.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aps.Formularios
{

    public partial class AddFilme : Form
    {
        public AddFilme()
        {
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

        private void AddFilme_Load(object sender, EventArgs e)
        {
            try
            {

                GetAllProdutos();
                GetAllGenero();
            }
            catch (Exception)
            {

                throw;
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

                            Form1 form = new Form1();

                            var ProdutoJsonString = await response.Content.ReadAsStringAsync();

                            var objGenero = JsonConvert.DeserializeObject<List<Genero>>(ProdutoJsonString);

                            List<String> genero = new List<string>();
                            var i = 0;
                            while (objGenero.Count > i)
                            {
                                if (objGenero[i].nome != null)
                                {
                                    genero.Add(objGenero[i].nome);
                                }
                                i++;
                            }
                            cmbGenero.DataSource = genero;


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

                            Form1 form = new Form1();

                            var ProdutoJsonString = await response.Content.ReadAsStringAsync();

                            var objData = JsonConvert.DeserializeObject<List<Diretor>>(ProdutoJsonString);
                            var i = 0;
                            // lista de nome do diretor

                            List<string> lista = new List<string>();

                            while (objData.Count > i)
                            {
                                if (objData[i].nome != null)
                                {
                                    lista.Add(objData[i].nome);
                                }
                                i++;
                            }
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
        private void pictureBox1_Click(object sender, EventArgs e)
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

                    else if (TxtDuracao.Text == "")
                    {
                        MessageBox.Show("ESCREVA A DURAÇÃO");
                    }

                    else if (TxtIdioma.Text == "")
                    {
                        MessageBox.Show("ESCREVA O IDIOMA");
                    }

                    else
                    {
                        DTO_Filme dto = new DTO_Filme()
                        {
                            titulo = txtNomeFilme.Text,
                            descricao = TxtDescricao.Text,
                            idiomaOriginal = TxtIdioma.Text,
                            dataLancamento = txtDtLancamento.Text,
                            duracao = TxtDuracao.Text,
                            genero = new Genero { nome = cmbGenero.Text },
                            diretor = new Diretor { nome = cmbDiretor.Text }
                        };

                        InserirFilmes(dto);

                        MessageBox.Show("Adicionado com Sucesso!!");

                        this.Close();

                    }
                }
                catch (Exception)
                {
                    throw;
                }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
