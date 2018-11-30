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
    public partial class Orçamento : Form
    {
        public Orçamento()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            global::Login.MenuCotação frm = new global::Login.MenuCotação();
            frm.Show();
            this.Visible = false;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            //MessageBox.Show("Conexão aberta!");

            comn.CommandText = "insert into orc_itens ( Orcamento, NCM, Quant_item)" +
                                "values ( @Orcamento, @NCM, @Quant_item)";
            comn.Parameters.AddWithValue("@Orcamento", this.textORCAMENTO.Text);
            comn.Parameters.AddWithValue("@NCM", this.textNCM.Text);
            comn.Parameters.AddWithValue("@Quant_item", this.textQUANT.Text);
            comn.ExecuteNonQuery();//gravar
            comn.Connection.Close();
            MessageBox.Show("Item inserido no orçamento " + textORCAMENTO.Text + "!");

            string ncm = textNCM.Text;
            if (ncm != "")
            {
                listBox1.Items.Add(ncm);
                textNCM.Clear();
                textNCM.Focus();
            }

            string quant = textQUANT.Text;
            if (quant != "")
            {
                listBox2.Items.Add(quant);
                textQUANT.Clear();
                textQUANT.Focus();
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            /*Abre a conexão*/
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();
            MessageBox.Show("Estabelecendo conexão com o banco...");

            try
            {
                /*Instrução sql*/
                comn.CommandText = "insert into orc_cliente ( cod_cliente, Total, n_parcelas)" +
                                   "values ( @cod_cliente, @Total, @n_parcelas)";

                /*Parametros*/
                comn.Parameters.AddWithValue("@cod_cliente", this.textCLIENTE.Text);
                comn.Parameters.AddWithValue("@Total", this.textTOTAL.Text);
                comn.Parameters.AddWithValue("@n_parcelas", this.textPARC.Text);
                comn.ExecuteNonQuery();//grava os registros
                MessageBox.Show("Orçamento cadastrado com sucesso!");

                string sql = "SELECT * FROM orc_cliente WHERE cod_cliente LIKE " + textCLIENTE.Text + "";
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
                        MessageBox.Show("Gerando código do orçamento...");
                        MessageBox.Show("Código: " + reader[0].ToString());
                        listBox3.Items.Add(reader[0].ToString());
                        textORCAMENTO.Text = reader.GetValue(0).ToString();

                    }
                    else
                        MessageBox.Show("Nenhum registro encontrado com o CNPJ informado!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
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



        private void btnGerar_Click(object sender, EventArgs e)
        {
            /*Abre a conexão*/
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Conexão aberta");



            comn.CommandText = "Gerar_parcela";

            comn.CommandType = CommandType.StoredProcedure;

            MessageBox.Show("Procedure ok");

            SqlParameter parameter = new SqlParameter();
            comn.Parameters.AddWithValue("@cod_cliente", textCLIENTE.Text);
            comn.Parameters.AddWithValue("@Total", textTOTAL.Text);
            comn.Parameters.AddWithValue("@n_parcela", textPARC.Text);
            SqlDataReader reader = comn.ExecuteReader();

            // Add the parameter to the Parameters collection. 
            comn.Parameters.Add(parameter);
            comn.Connection.Close();
            MessageBox.Show("Parcela gerada com sucesso!");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            /*Abrindo a conexão*/
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Estabelecendo conexão com o banco...");



            try
            {
                /*Comando sql*/
                comn.CommandText = "UPDATE orc_cliente " +
                                   "SET Total = " + textTOTAL.Text + ", " +
                                   "n_parcela = " + textPARC.Text + " " +
                                   "where cod_cliente = " + textCLIENTE.Text + "";

                comn.ExecuteScalar();//grava os registros
                comn.Connection.Close();
                MessageBox.Show("Cliente" + textCLIENTE.Text + "alterado com sucesso!");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro!" + ex.Message);
                return;
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Estabelecendo conexão com o banco...");

            /*comando sql*/
            string sql = "SELECT * FROM orc_cliente WHERE cod_cliente LIKE " + textCLIENTE.Text + "";
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
  
                    textTOTAL.Text = reader.GetValue(2).ToString();
                    textPARC.Text = reader.GetValue(3).ToString();

                }
                else
                    MessageBox.Show("Nenhum registro encontrado para o código informado!");


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

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Estabelecendo conexão com o banco...");

            /*comando sql*/
            string sql = "SELECT Parcela FROM parcela WHERE cod_cliente LIKE " + textCLIENTE.Text + "";
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
                    listBoxParc.Items.Add(reader[0].ToString());

                }
                else
                    MessageBox.Show("Nenhum registro encontrado para o código informado!");


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

        private void btnItem_Click(object sender, EventArgs e)
        {
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Estabelecendo conexão com o banco...");

            /*comando sql*/
            string sql = "SELECT NCM, Quant_item FROM orc_itens WHERE Orcamento LIKE " + textORCAMENTO.Text + "";
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
                    listBox1.Items.Add(reader[0].ToString());
                    listBox2.Items.Add(reader[1].ToString());

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

        private void button1_Click(object sender, EventArgs e)
        {
            global::Login.RelatorioCotação frm = new global::Login.RelatorioCotação();
            frm.Show();
            this.Visible = false;
        }
    }
}
