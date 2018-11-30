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
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            global::Login.Menu frm = new global::Login.Menu();
            frm.Show();
            this.Visible = false;
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            global::Login.CadastroCliente frm = new global::Login.CadastroCliente();
            frm.Show();
            this.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            global::Login.BuscarCliente frm = new global::Login.BuscarCliente();
            frm.Show();
            this.Visible = false;
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            global::Login.Relatorio frm = new global::Login.Relatorio();
            frm.Show();
            this.Visible = false;
        }
    }
}
