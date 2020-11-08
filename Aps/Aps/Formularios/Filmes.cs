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

                throw ex;
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
                    txtFilme1.Text = objData[i].titulo;
                    txtDuracao1.Text = objData[i].duracao;
                    txtGenero1.Text = objData[i].generoId.ToString();
                    txtLancamento1.Text = objData[i].dataLancamento.ToString();
                    txtIdioma1.Text = objData[i].idiomaOriginal;
                    txtDiretor1.Text = objData[i].diretor.nome;
                    txtDescricao1.Text = objData[i].descricao;
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
                    txtFilme2.Text = objData[i + 1].titulo;
                    txtDuracao2.Text = objData[i + 1].duracao;
                    txtGenero2.Text = objData[i + 1].generoId.ToString();
                    txtLancamento2.Text = objData[i + 1].dataLancamento.ToString();
                    txtIdioma2.Text = objData[i + 1].idiomaOriginal;
                    txtDiretor2.Text = objData[i + 1].diretor.nome;
                    txtDescricao2.Text = objData[i + 1].descricao;
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
                    txtFilme3.Text = objData[i + 2].titulo;
                    txtDuracao3.Text = objData[i + 2].duracao;
                    txtGenero3.Text = objData[i + 2].generoId.ToString();
                    txtLancamento3.Text = objData[i + 2].dataLancamento.ToString();
                    txtIdioma3.Text = objData[i + 2].idiomaOriginal;
                    txtDiretor3.Text = objData[i + 2].diretor.nome;
                    txtDescricao3.Text = objData[i + 2].descricao;
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
                    txtFilme4.Text = objData[i + 3].titulo;
                    txtDuracao4.Text = objData[i + 3].duracao;
                    txtGenero4.Text = objData[i + 3].generoId.ToString();
                    txtLancamento4.Text = objData[i + 3].dataLancamento.ToString();
                    txtIdioma4.Text = objData[i + 3].idiomaOriginal;
                    txtDiretor4.Text = objData[i + 3].diretor.nome;
                    txtDescricao4.Text = objData[i + 3].descricao;
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
                    txtFilme5.Text = objData[i + 4].titulo;
                    txtDuracao5.Text = objData[i + 4].duracao;
                    txtGenero5.Text = objData[i + 4].generoId.ToString();
                    txtLancamento5.Text = objData[i + 4].dataLancamento.ToString();
                    txtIdioma5.Text = objData[i + 4].idiomaOriginal;
                    txtDiretor5.Text = objData[i + 4].diretor.nome;
                    txtDescricao5.Text = objData[i + 4].descricao;
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
                    txtFilme6.Text = objData[i + 5].titulo;
                    txtDuracao6.Text = objData[i + 5].duracao;
                    txtGenero6.Text = objData[i + 5].generoId.ToString();
                    txtLancamento6.Text = objData[i + 5].dataLancamento.ToString();
                    txtIdioma6.Text = objData[i + 5].idiomaOriginal;
                    txtDiretor6.Text = objData[i + 5].diretor.nome;
                    txtDescricao6.Text = objData[i + 5].descricao;
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
                    txtFilme7.Text = objData[i + 6].titulo;
                    txtDuracao7.Text = objData[i + 6].duracao;
                    txtGenero7.Text = objData[i + 6].generoId.ToString();
                    txtLancamento7.Text = objData[i + 6].dataLancamento.ToString();
                    txtIdioma7.Text = objData[i + 6].idiomaOriginal;
                    txtDiretor7.Text = objData[i + 6].diretor.nome;
                    txtDescricao7.Text = objData[i + 6].descricao;
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
                    txtFilme8.Text = objData[i + 7].titulo;
                    txtDuracao8.Text = objData[i + 7].duracao;
                    txtGenero8.Text = objData[i + 7].generoId.ToString();
                    txtLancamento8.Text = objData[i + 7].dataLancamento.ToString();
                    txtIdioma8.Text = objData[i + 7].idiomaOriginal;
                    txtDiretor8.Text = objData[i + 7].diretor.nome;
                    txtDescricao8.Text = objData[i + 7].descricao;
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
    }
}
