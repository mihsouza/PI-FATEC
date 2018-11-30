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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            global::Login.Cliente frm = new global::Login.Cliente();
            frm.Show();
            this.Visible = false;
        }

        private void btnRetorno_Click(object sender, EventArgs e)
        {
            global::Login.MenuRetorno frm = new global::Login.MenuRetorno();
            frm.Show();
            this.Visible = false;
        }

        private void btnCotaçao_Click(object sender, EventArgs e)
        {
            global::Login.MenuCotação frm = new global::Login.MenuCotação();
            frm.Show();
            this.Visible = false;
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            global::Login.Item frm = new global::Login.Item();
            frm.Show();
            this.Visible = false;
        }
    }
 }

