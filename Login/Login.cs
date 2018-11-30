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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            int cod_cliente;
          
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Estabelecendo conexão com o banco...");

            /*comando sql*/
            string sql = "SELECT cod FROM login_tab WHERE Usuario LIKE '" + textUsu.Text + "' and Senha like "+textSenha.Text+"";
            SqlCommand cmd = new SqlCommand(sql, comn.Connection);
            //MessageBox.Show("SQL executado");

            cmd.CommandType = CommandType.Text;
            //MessageBox.Show("Comando executado" + cmd.CommandType);

            SqlDataReader reader;

            try
            {
                reader = cmd.ExecuteReader();
                //MessageBox.Show("Reader" + reader);

                if (reader.Read())
                {
                    cod_cliente = Convert.ToInt16(reader.GetValue(0).ToString());

                    if(cod_cliente == 01)
                    {
                        global::Login.Menu frm = new global::Login.Menu();
                        frm.Show();
                        this.Visible = false;
                        MessageBox.Show("***Bem vindo " + textUsu.Text + "!***");
                    }
                    else if(cod_cliente == 02)
                    {
                        global::Login.MenuADM frm = new global::Login.MenuADM();
                        frm.Show();
                        this.Visible = false;
                        MessageBox.Show("***Bem vindo " + textUsu.Text + "!***");
                    }
                    else
                    {
                        MessageBox.Show(" Codigo invalido ");
                    }
                    //MessageBox.Show("Cod " + textUsu.Text + "\n" + reader[0].ToString());
                   
                    


                }
                else
                    MessageBox.Show("Usuario ou senha incompativel!");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                comn.Connection.Close();
            }

            /*if ((textBox1.Text == "ADMINISTRACAO") && (textBox2.Text == "ADM123"))
            {
                MessageBox.Show("***Bem vindo Ana Paula!***");
                global::Login.MenuADM frm = new global::Login.MenuADM();
                frm.Show();
                this.Visible = false;
            }
            else
                if ((textBox1.Text == "TECNICO") && (textBox2.Text == "TEC123"))
            {
                MessageBox.Show("***Bem vindo Claudinei!***");
                global::Login.Menu frm = new global::Login.Menu();
                frm.Show();
                this.Visible = false;
            }
            else
                if ((textBox1.Text == "GERENCIA") && (textBox2.Text == "GER123"))
            {
                MessageBox.Show("***Bem vindo Jorge!***");
                global::Login.Menu frm = new global::Login.Menu();
                frm.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("LOGIN OU SENHA INVALIDOS!");
            }*/
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal class PROJETOJCSEDataSet
        {
            internal object cliente;

            public PROJETOJCSEDataSet()
            {
            }
        }

        internal class PROJETOJCSEDataSetTableAdapters
        {
            internal class clienteTableAdapter
            {
                public clienteTableAdapter()
                {
                }

                internal void Fill(object cliente)
                {
                    throw new NotImplementedException();
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            global::Login.CadastroLogin frm = new global::Login.CadastroLogin();
            frm.Show();
            this.Visible = false;
        }
    }
}
