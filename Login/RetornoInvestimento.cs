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
    public partial class RetornoInvestimento : Form
    {
        public RetornoInvestimento()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            global::Login.Menu frm = new global::Login.Menu();
            frm.Show();
            this.Visible = false;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            global::Login.MenuRetorno frm = new global::Login.MenuRetorno();
            frm.Show();
            this.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            /*Abre a conexão*/
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Conexão aberta");

            /*Comando sql*/
            /*SqlCommand cmd = new SqlCommand("consumo_analise", comn);
            cmd.CommandType = CommandType.StoredProcedure;
            //comn.Parameters.AddWithValue("@cod_cliente", this.textCLIENTE.Text);
            //SqlCommand cmd = new SqlCommand(sql, comn.Connection);
            MessageBox.Show("SQL executado");

            //cmd.CommandType = CommandType.StoredProcedure;
            MessageBox.Show("Comando executado" + cmd.CommandType);

            SqlDataReader reader;*/

            comn.CommandText = "consumo_analise";

            comn.CommandType = CommandType.StoredProcedure;

            MessageBox.Show("Procedure ok");

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@cod_cliente";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = textCLIENTE.Text;


            // Add the parameter to the Parameters collection. 
            comn.Parameters.Add(parameter);
            SqlDataReader reader = comn.ExecuteReader();
            comn.Connection.Close();
            MessageBox.Show("Analise gerada com sucesso!");

            //cmd.Connection = comn;

            /*SqlParameter cod_cliente = new SqlParameter("@cod_cliente", this.textCLIENTE.Text);
            SqlParameter media = new SqlParameter("@media", SqlDbType.Money);

            media.Value = media.SqlValue;

            comn.Parameters.Add(media);*/

            /* try
             {
                 reader = comn.ExecuteReader();
                 MessageBox.Show("Reader" + reader);

                 if (reader.Read())
                 {
                     MessageBox.Show("foi!!!");
                     MessageBox.Show(reader[0].ToString());

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
             }*/
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            /*Abre a conexão*/
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Estabelecendo conexão com o banco...");

            /*Comando sql*/
            string sql = "SELECT Ano, Consumo_media, Producao, Consumo_sem, Consumo_com, Beneficio " +
                        "FROM analise " +
                        "WHERE cod_cliente = " + textCLIENTE.Text + "";
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
                    //MessageBox.Show(reader[0].ToString() + reader[1].ToString() + reader[2].ToString() + reader[4].ToString());
                    listBoxANO.Items.Add(reader[0].ToString());
                    listBox1.Items.Add(reader[1].ToString());
                    listBox2.Items.Add(reader[2].ToString());
                    listBox3.Items.Add(reader[3].ToString());
                    listBox4.Items.Add(reader[4].ToString());
                    listBox5.Items.Add(reader[5].ToString());
                }
                /*else
                    MessageBox.Show("Nenhum registro encontrado para o cliente informado!");*/


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
