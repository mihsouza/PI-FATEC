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
    public partial class Item : Form
    {
        public Item()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            global::Login.Menu frm = new global::Login.Menu();
            frm.Show();
            this.Visible = false;
        }

        private void btnCadastrarItem_Click(object sender, EventArgs e)
        {
            try
            {
                /*Abrindo a conexão*/
                SqlCommand comn = new SqlCommand();
                comn.Connection = DATABASE.abrir();
                MessageBox.Show("Estabelecendo conexão com o banco...");

                /*Parametro SQL*/
                comn.CommandText = "insert into itens ( NCM, descri_item)" +
                                    "values ( @NCM, @descri_item)";
                comn.Parameters.AddWithValue("@NCM", this.textNCM.Text);
                comn.Parameters.AddWithValue("@descri_item", this.textDESC.Text);
                comn.ExecuteNonQuery();/*grava os registros*/
                comn.Connection.Close();
                MessageBox.Show("Item " + textNCM.Text + " cadastrado com sucesso!");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
        }

        private void btnBuscarNCM_Click(object sender, EventArgs e)
        {
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Estabelecendo conexão com o banco...");

            string sql = "SELECT DESCRI_ITEM FROM ITENS WHERE NCM LIKE " + textNCM.Text +"";
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
                    //MessageBox.Show("Item " + textNCM.Text  + "\n" + reader[0].ToString());
                    textDESC.Text = reader.GetValue(0).ToString();
                }
                else
                    MessageBox.Show("Nenhum registro encontrado com o NCM informado!");


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
            /*string connectionString = "Data Source = LAPTOP-1Q9K28V3; Initial Catalog = PROJETOJCSE; User ID =teste; Password =123456";
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();
            */
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Estabelecendo conexão com o banco...");

            string sql = "SELECT * FROM ITENS";
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
                        //MessageBox.Show("foi!!!");
                        //MessageBox.Show(reader[0].ToString() + reader[1].ToString());
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
    }
}
