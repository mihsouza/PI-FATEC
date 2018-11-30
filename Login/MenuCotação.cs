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
    public partial class MenuCotação : Form
    {
        public MenuCotação()
        {
            InitializeComponent();
        }

        private void btnConsulmo_Click(object sender, EventArgs e)
        {
            global::Login.CadastroConsumo frm = new global::Login.CadastroConsumo();
            frm.Show();
            this.Visible = false;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            global::Login.Menu frm = new global::Login.Menu();
            frm.Show();
            this.Visible = false;
        }

        private void btnCotação_Click(object sender, EventArgs e)
        {
            global::Login.Media frm = new global::Login.Media();
            frm.Show();
            this.Visible = false;
        }
    }
}
