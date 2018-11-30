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
    public partial class RelatorioCotação : Form
    {
        public RelatorioCotação()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            global::Login.MenuCotação frm = new global::Login.MenuCotação();
            frm.Show();
            this.Visible = false;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            /*Abre a conexão*/
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Esabelecendo conexão com o banco...");

            /*Comando sql*/
            string sql = "SELECT * FROM orc_cliente WHERE cod_cliente LIKE "+ textCLIENTE.Text +"";
            SqlCommand cmd = new SqlCommand(sql, comn.Connection);
            //MessageBox.Show("SQL executado");

            cmd.CommandType = CommandType.Text;
            MessageBox.Show("Comando executado" + cmd.CommandType);

            SqlDataReader reader;

            try
            {
                reader = cmd.ExecuteReader();
                //MessageBox.Show("Reader" + reader);

                if (reader.Read())
                {
                    MessageBox.Show("Conexão estabelecida!");
                    //MessageBox.Show(reader[0].ToString() + reader[1].ToString() + reader[2].ToString() + reader[4].ToString());
                    listBoxCod.Items.Add(reader[0].ToString());
                    listBox1.Items.Add(reader[1].ToString());
                    listBox2.Items.Add(reader[2].ToString());
                    listBox3.Items.Add(reader[3].ToString());
                }
                else
                    MessageBox.Show("Nenhum registro encontrado para o cliente informado!");


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
            /*Abre a conexão*/
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Conexão aberta");

            /*Comando sql*/
            string sql = "SELECT * FROM orc_cliente";
            comn.Parameters.AddWithValue("@cod_cliente", this.textCLIENTE.Text);
            SqlCommand cmd = new SqlCommand(sql, comn.Connection);
            //MessageBox.Show("SQL executado");

            cmd.CommandType = CommandType.Text;
           // MessageBox.Show("Comando executado" + cmd.CommandType);

            SqlDataReader reader;

            try
            {
                reader = cmd.ExecuteReader();
                //MessageBox.Show("Reader" + reader);

                while (reader.Read() !=false)
                {
                    //MessageBox.Show("foi!!!");
                    //MessageBox.Show(reader[0].ToString() + reader[1].ToString() + reader[2].ToString() + reader[4].ToString());
                    listBoxCod.Items.Add(reader[0].ToString());
                    listBox1.Items.Add(reader[1].ToString());
                    listBox2.Items.Add(reader[2].ToString());
                    listBox3.Items.Add(reader[3].ToString());
                    

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





