using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class MenuADM : Form
    {
        public MenuADM()
        {
            InitializeComponent();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            global::Login.Cliente frm = new global::Login.Cliente();
            frm.Show();
            this.Visible = false;
        }

        private void btnRetorno_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Usuário sem permissão! Favor contactar o administrador.");
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            global::Login.ItemADM frm = new global::Login.ItemADM();
            frm.Show();
            this.Visible = false;
        }

        private void btnCotaçao_Click(object sender, EventArgs e)
        {
            global::Login.MenuCotação frm = new global::Login.MenuCotação();
            frm.Show();
            this.Visible = false;
        }
    }
}
