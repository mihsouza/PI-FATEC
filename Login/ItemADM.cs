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
    public partial class ItemADM : Form
    {
        public ItemADM()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            global::Login.MenuADM frm = new global::Login.MenuADM();
            frm.Show();
            this.Visible = false;
        }

        private void btnCadastrarItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Usuário sem permissão! Favor contactar o administrador");
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarNCM_Click(object sender, EventArgs e)
        {
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Estabelecendo conexão com o banco...");

            string sql = "SELECT DESCRI_ITEM FROM ITENS WHERE NCM LIKE " + textNCM.Text + "";
            SqlCommand cmd = new SqlCommand(sql, comn.Connection);
            //MessageBox.Show("SQL executado");

            cmd.CommandType = CommandType.Text;
            //MessageBox.Show("Comando executado" + cmd.CommandType);

            SqlDataReader reader;

            try
            {
                reader = cmd.ExecuteReader();
                //MessageBox.Show("Reader" + reader);

                while (reader.Read() != false)
                {
                    //MessageBox.Show("Item " + textNCM.Text + "\n" + reader[0].ToString());

                    listBoxDESC.Items.Add(reader[0].ToString());
                    listBox1.Items.Add(reader[1].ToString());
                    
                }
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                comn.Connection.Close();
            }
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Estabelecendo conexão com o banco...");

            string sql = "SELECT * FROM ITENS";
            SqlCommand cmd = new SqlCommand(sql, comn.Connection);
            MessageBox.Show("SQL executado");

            cmd.CommandType = CommandType.Text;
            MessageBox.Show("Comando executado" + cmd.CommandType);

            SqlDataReader reader;

            try
            {
                reader = cmd.ExecuteReader();
                MessageBox.Show("Reader" + reader);

                if (reader.Read())
                {
                    MessageBox.Show("foi!!!");
                    MessageBox.Show(reader[0].ToString() + reader[1].ToString());
                    listBoxDESC.Items.Add(reader[0].ToString() + " | " + reader[1].ToString());

                }
                else
                {
                    MessageBox.Show("Nenhum registro encontrado com o Id informado!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                comn.Connection.Close();
            }
        }
    }
}
