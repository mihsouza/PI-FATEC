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
    public partial class Relatorio : Form
    {
        public Relatorio()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            global::Login.Cliente frm = new global::Login.Cliente();
            frm.Show();
            this.Visible = false;
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Conexão aberta");

            string sql = "SELECT * FROM cliente";
            SqlCommand cmd = new SqlCommand(sql, comn.Connection);
            MessageBox.Show("SQL executado");

            cmd.CommandType = CommandType.Text;
            //MessageBox.Show("Comando executado" + cmd.CommandType);

            SqlDataReader reader;

            try
            {
                reader = cmd.ExecuteReader();
                //MessageBox.Show("Reader" + reader);

                while (reader.Read() != false)
                {
                    
                    //MessageBox.Show(reader[0].ToString() + reader[1].ToString());
                    listBoxCliente.Items.Add(reader[0].ToString());
                    listBox1.Items.Add(reader[1].ToString());
                    listBox2.Items.Add(reader[2].ToString());
                    listBox3.Items.Add(reader[3].ToString());
                    listBox4.Items.Add(reader[4].ToString());
                    listBox5.Items.Add(reader[5].ToString());
                    listBox6.Items.Add(reader[6].ToString());
                    listBox7.Items.Add(reader[7].ToString());
                    listBox8.Items.Add(reader[9].ToString());
                    listBox9.Items.Add(reader[9].ToString());
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

