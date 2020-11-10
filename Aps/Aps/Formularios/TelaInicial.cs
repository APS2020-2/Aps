using System;
using System.Windows.Forms;

namespace Aps
{
    public partial class TelaIncial : Form
    {
        public TelaIncial()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btIniciar_Click(object sender, EventArgs e)
        {
            ListaPrincipal janela2 = new ListaPrincipal();
            this.Visible = false;
            janela2.Show();
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
