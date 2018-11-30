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
    public partial class CadastroConsumo : Form
    {
        public CadastroConsumo()
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

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                /*Abre a conexão*/
                SqlCommand comn = new SqlCommand();
                comn.Connection = DATABASE.abrir();


                /*Comando sql*/
                comn.CommandText = "insert into consumo_cliente ( cod_cliente, Consumo_kWh, Mes)" +
                                    "values ( @cod_cliente, @Consumo_kWh, @Mes)";
                comn.Parameters.AddWithValue("@cod_cliente", this.textCLIENTE.Text);
                comn.Parameters.AddWithValue("@Consumo_kWh", this.textCONSUMO.Text);
                comn.Parameters.AddWithValue("@Mes", this.textDATA.Text);
                comn.ExecuteNonQuery();//grava os registros
                comn.Connection.Close();
                MessageBox.Show("Consumo cadastrado com sucesso!");

                /*Joga os valores gravados para a list box*/

                string consumo = textCONSUMO.Text;
                if (consumo != "")
                {
                    listBox3.Items.Add(consumo);
                    textCONSUMO.Clear();
                    textCONSUMO.Focus();
                }

                string data = textDATA.Text;
                if (data != "")
                {
                    listBox2.Items.Add(data);
                    textDATA.Clear();
                    textDATA.Focus();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
        }
        }
    }

