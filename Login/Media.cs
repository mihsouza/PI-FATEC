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
    public partial class Media : Form
    {
        public Media()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            global::Login.MenuCotação frm = new global::Login.MenuCotação();
            frm.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*Abre a conexão*/
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Estabelecendo conexão com o banco...");

            /*Comando sql*/
            string sql = "select AVG(consumo_kWh) from consumo_cliente where cod_cliente = "+ textCLIENTE.Text+"";
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
                    listBoxMedia.Items.Add(reader[0].ToString());

                }
                else
                    MessageBox.Show("Nenhum registro encontrado com o Codigo informado!");


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

        private void Media_Load(object sender, EventArgs e)
        {

        }
    }
}
