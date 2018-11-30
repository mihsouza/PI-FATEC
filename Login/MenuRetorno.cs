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
    public partial class MenuRetorno : Form
    {
        public MenuRetorno()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            global::Login.Menu frm = new global::Login.Menu();
            frm.Show();
            this.Visible = false;
        }

        private void btnInvestimento_Click(object sender, EventArgs e)
        {
            global::Login.Orçamento frm = new global::Login.Orçamento();
            frm.Show();
            this.Visible = false;
        }

        private void btnEconomia_Click(object sender, EventArgs e)
        {
            global::Login.RetornoInvestimento frm = new global::Login.RetornoInvestimento();
            frm.Show();
            this.Visible = false;
        }
    }
}
