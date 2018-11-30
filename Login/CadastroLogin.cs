using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login
{
    public partial class CadastroLogin : Form
    {
        public CadastroLogin()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if(textSenha.Text == textConfiSenha.Text)
                {
                try
                {
                    /*Abrindo a conexão*/
                    SqlCommand comn = new SqlCommand();
                    comn.Connection = DATABASE.abrir();
                    MessageBox.Show("Gravando dados no banco...");

                    /*Parametro SQL*/
                    comn.CommandText = "insert into login_tab ( Usuario, Senha, Cod)" +
                                        " values ( @Usuario, @Senha, @Cod)";
                    comn.Parameters.AddWithValue("@Usuario", this.textUsu.Text);
                    comn.Parameters.AddWithValue("@Senha", this.textSenha.Text);
                    comn.Parameters.AddWithValue("@Cod", this.textCod.Text);
                    comn.ExecuteNonQuery();/*grava os registros*/
                    comn.Connection.Close();
                    MessageBox.Show("Usuario cadastrado com sucesso!");
                    global::Login.Login frm = new global::Login.Login();
                    frm.Show();
                    this.Visible = false;

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
            }
            else
            {

                MessageBox.Show("Senhas não correspondem!");
            }

        }
    }
}

