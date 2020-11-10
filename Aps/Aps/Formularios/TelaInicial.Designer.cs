namespace Aps
{
    partial class TelaIncial
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaIncial));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btIniciar = new System.Windows.Forms.PictureBox();
            this.btSair = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btIniciar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btSair)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(300, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 135);
            this.panel1.TabIndex = 1;
            // 
            // btIniciar
            // 
            this.btIniciar.BackColor = System.Drawing.Color.Transparent;
            this.btIniciar.Image = global::Aps.Properties.Resources.btIniciar;
            this.btIniciar.Location = new System.Drawing.Point(300, 201);
            this.btIniciar.Name = "btIniciar";
            this.btIniciar.Size = new System.Drawing.Size(200, 30);
            this.btIniciar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btIniciar.TabIndex = 2;
            this.btIniciar.TabStop = false;
            this.btIniciar.Click += new System.EventHandler(this.btIniciar_Click);
            // 
            // btSair
            // 
            this.btSair.BackColor = System.Drawing.Color.Transparent;
            this.btSair.Image = global::Aps.Properties.Resources.btSair;
            this.btSair.Location = new System.Drawing.Point(688, 408);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(100, 30);
            this.btSair.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btSair.TabIndex = 3;
            this.btSair.TabStop = false;
            this.btSair.Click += new System.EventHandler(this.btSair_Click);
            // 
            // TelaIncial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btSair);
            this.Controls.Add(this.btIniciar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "TelaIncial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.btIniciar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btSair)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btIniciar;
        private System.Windows.Forms.PictureBox btSair;
    }
}

