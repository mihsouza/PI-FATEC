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
    public partial class CadastroCliente : Form
    {
        public CadastroCliente()
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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {


                /*Abre a conexão*/
                SqlCommand comn = new SqlCommand();
                comn.Connection = DATABASE.abrir();
                MessageBox.Show("Estabelecendo conexão com o banco...");

                try
                {
                    /*Instrução sql*/
                    comn.CommandText = "INSERT INTO cliente ( CNPJ, Nome , Rua, n, Bairro, CEP, Cidade, UF, Telefone, Email) " +
                                       "VALUES ( @CNPJ, @Nome, @Rua, @n, @Bairro, @CEP, @Cidade, @UF, @Telefone, @Email)"; 

                /*Parametros*/
                   comn.Parameters.AddWithValue("@CNPJ", textCNPJ.Text);
                   comn.Parameters.AddWithValue("@Nome", textRAZAO.Text);
                   comn.Parameters.AddWithValue("@Rua", textRUA.Text);
                   comn.Parameters.AddWithValue("@n", textNUM.Text);
                   comn.Parameters.AddWithValue("@Bairro", textBAIRRO.Text);
                   comn.Parameters.AddWithValue("@CEP", textCEP.Text);
                   comn.Parameters.AddWithValue("@Cidade", textCIDADE.Text);
                   comn.Parameters.AddWithValue("@UF", textUF.Text);
                   comn.Parameters.AddWithValue("@Telefone", textTEL.Text);
                   comn.Parameters.AddWithValue("@Email", textEMAIL.Text);

                   comn.ExecuteNonQuery();//grava os registros

                       MessageBox.Show("Cliente cadastrado com sucesso!");

                       string sql = "SELECT cod_cliente FROM cliente WHERE CNPJ LIKE '" + textCNPJ.Text + "'";
                       //string sql = "SELECT * FROM cliente WHERE cod_cliente LIKE '" + textcod_cliente.Text + "'";
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
                        MessageBox.Show("FOI!!!");
                        MessageBox.Show(reader[0].ToString()); //+ "|" + reader[1].ToString() + "|" + reader[2].ToString() + "|" + reader[3].ToString() + "|" + reader[6].ToString() + "|" + reader[7].ToString() + "|" + reader[8].ToString() + "|" + reader[9].ToString() + "\n");
                    }

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

                   /*Instrução sql*/
                /*comn.CommandText = "insert into cliente ( CNPJ, Nome, Rua, N, Bairro, CEP, Cidade, UF, Email, Telefone)" +
                             "values ( @CNPJ, @Nome, @Rua, @N, @Bairro, @CEP, @Cidade, @UF, @Email, @Telefone)";

                /*Parametros*/
                /*comn.Parameters.AddWithValue("@CNPJ", this.textCNPJ.Text);
                comn.Parameters.AddWithValue("@Nome", this.textRAZAO.Text);
                comn.Parameters.AddWithValue("@Rua", this.textRUA.Text);
                comn.Parameters.AddWithValue("@n", this.textNUM.Text);
                comn.Parameters.AddWithValue("@Bairro", this.textBAIRRO.Text);
                comn.Parameters.AddWithValue("@CEP", this.textCEP.Text);
                comn.Parameters.AddWithValue("@Cidade", this.textCIDADE.Text);
                comn.Parameters.AddWithValue("@UF", this.textUF.Text);
                comn.Parameters.AddWithValue("@Email", this.textEMAIL.Text);
                comn.Parameters.AddWithValue("@Telefone", this.textTEL.Text);
                comn.ExecuteNonQuery();//grava os registros
                comn.Connection.Close();
                MessageBox.Show("Orçamento cadastrado com sucesso!");*/

            }




            private void btnConsumo_Click(object sender, EventArgs e)
            {
                global::Login.CadastroConsumo frm = new global::Login.CadastroConsumo();
                frm.Show();
                this.Visible = false;
            }

            private void textEMAIL_TextChanged(object sender, EventArgs e)
            {

            }

            private void textTEL_TextChanged(object sender, EventArgs e)
            {

            }

            private void textUF_TextChanged(object sender, EventArgs e)
            {

            }

            private void textCIDADE_TextChanged(object sender, EventArgs e)
            {

            }

            private void textCEP_TextChanged(object sender, EventArgs e)
            {

            }

            private void textBAIRRO_TextChanged(object sender, EventArgs e)
            {

            }

            private void textNUM_TextChanged(object sender, EventArgs e)
            {

            }

            private void textRUA_TextChanged(object sender, EventArgs e)
            {

            }

            private void textRAZAO_TextChanged(object sender, EventArgs e)
            {

            }

            private void textCNPJ_TextChanged(object sender, EventArgs e)
            {

            }

            private void label12_Click(object sender, EventArgs e)
            {

            }

            private void label11_Click(object sender, EventArgs e)
            {

            }

            private void label10_Click(object sender, EventArgs e)
            {

            }

            private void label9_Click(object sender, EventArgs e)
            {

            }

            private void label8_Click(object sender, EventArgs e)
            {

            }

            private void label7_Click(object sender, EventArgs e)
            {

            }

            private void label6_Click(object sender, EventArgs e)
            {

            }

            private void label5_Click(object sender, EventArgs e)
            {

            }

            private void label4_Click(object sender, EventArgs e)
            {

            }

            private void label2_Click(object sender, EventArgs e)
            {

            }

            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void pictureBox1_Click(object sender, EventArgs e)
            {

            }

            private void CadastroCliente_Load(object sender, EventArgs e)
            {

            }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
        }

