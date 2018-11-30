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
    public partial class BuscarCliente : Form
    {
        public BuscarCliente()
        {
            InitializeComponent();
        }

        private void btnConsumo_Click(object sender, EventArgs e)
        {
            /*Abrindo a conexão*/
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Estabelecendo conexão com o banco...");



            try
            {
                /*Comando sql*/
                comn.CommandText = "DELETE FROM cliente where cod_cliente LIKE " + textCod.Text +"";

                comn.ExecuteScalar();//grava os registros
                comn.Connection.Close();
                MessageBox.Show("Cliente " + textCod.Text + " excluido com sucesso!");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro!" + ex.Message);
                return;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Estabelecendo conexão com o banco...");

            /*comando sql*/
            string sql = "SELECT * FROM cliente WHERE cod_cliente LIKE " + textCod.Text + "";
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
                    // MessageBox.Show("Comando executado com sucesso!");
                    /*MessageBox.Show("Código: " + reader[0].ToString() + "|CNPJ:" + reader[1].ToString() + "\n" +
                                    " |Razão Social: " + reader[2].ToString() + "\n" +
                                    " |Rua:" + reader[3].ToString() + " |Numero:" + reader[4].ToString() + "\n" +
                                    " |Bairro:" + reader[5].ToString() + "\n" +
                                    " |Cidade:" + reader[6].ToString() + " |UF:" + reader[7].ToString() + "\n" +
                                    " |Email:" + reader[8].ToString() + " |Telefone:" + reader[9].ToString());*/
                    textCNPJ.Text = reader.GetValue(1).ToString();
                    textRAZAO.Text = reader.GetValue(2).ToString();
                    textRUA.Text = reader.GetValue(3).ToString();
                    textNUM.Text = reader.GetValue(4).ToString();
                    textBAIRRO.Text = reader.GetValue(5).ToString();
                    textCEP.Text = reader.GetValue(6).ToString();
                    textCIDADE.Text = reader.GetValue(7).ToString();
                    textUF.Text = reader.GetValue(8).ToString();
                    textTEL.Text = reader.GetValue(8).ToString();
                    textEMAIL.Text = reader.GetValue(10).ToString();


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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            /*Abrindo a conexão*/
            SqlCommand comn = new SqlCommand();
            comn.Connection = DATABASE.abrir();

            MessageBox.Show("Estabelecendo conexão com o banco...");



            try
            {
                /*Comando sql*/
                comn.CommandText = "UPDATE cliente " +
                                   "SET CNPJ = '" + textCNPJ.Text + "'," +
                                   "Nome = '" + textRAZAO.Text + "'," +
                                   "Rua = '" + textRAZAO.Text + "'," +
                                   "n = '" + textNUM.Text + "'," +
                                   "Bairro = '" + textBAIRRO.Text + "'," +
                                   "CEP = '" + textCEP.Text + "'," +
                                   "Cidade = '" + textCIDADE.Text + "'," +
                                   "UF = '" + textUF.Text + "'," +
                                   "Email = '" + textEMAIL.Text + "'," +
                                   "Telefone = '" + textTEL.Text + "'" +
                                   "where cod_cliente = " + textCod.Text + "";

                comn.ExecuteScalar();//grava os registros
                comn.Connection.Close();
                MessageBox.Show("Cliente" + textCod.Text + "alterado com sucesso!");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro!" + ex.Message);
                return;
            }
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
    }
}
