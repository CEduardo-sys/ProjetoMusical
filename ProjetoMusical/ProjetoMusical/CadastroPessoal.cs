using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Data.SqlClient;

namespace ProjetoMusical
{
    public partial class CadastroPessoal : Form
    {
        Thread t1;

        public CadastroPessoal()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void CadastroPessoal_Load(object sender, EventArgs e)
        {

        }

        private void butLimpar_Click(object sender, EventArgs e)
        {
            textName2.Clear();
            textNasci.Clear();
            textCPF.Clear();
            textBoxRua.Clear();
            textEmail.Clear();
            textTelefone.Clear();
            textUF.Clear();
            textCidade.Clear();
        }

        private void butConcluir_Click(object sender, EventArgs e)
        {

            String Sexualidade = "";


            if (textName2.Text == "")
            {
                MessageBox.Show("Erro! Digite o Nome do Cliente!", "Faltando informações!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textName2.Focus();
                return;
            }
            if (textNasci.Text == "")
            {
                MessageBox.Show("Erro! Digite a data de nascimento!", "Faltando informações!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textNasci.Focus();
            }
            if (textCPF.Text == "")
            {
                MessageBox.Show("Erro! Digite o CPF!", "Faltando informações!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textCPF.Focus();
            }
            if (textBoxRua.Text == "")
            {
                MessageBox.Show("Erro! Digite o RG!", "Faltando informações!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxRua.Focus();
            }
            if (textCidade.Text == "")
            {
                MessageBox.Show("Erro! Digite a cidade!", "Faltando informações!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textCidade.Focus();
            }
            if (textUF.Text == "")
            {
                MessageBox.Show("Erro! Digite o Estado!", "Faltando informações!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textUF.Focus();
            }
            if (textTelefone.Text == "")
            {
                MessageBox.Show("Erro! Digite o número de telefone!", "Faltando informações!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textUF.Focus();
            }
            if (textEmail.Text == "")
            {
                MessageBox.Show("Erro! Digite o Email", "Faltando informações!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textEmail.Focus();
            }

            if (radioMasc.Checked == true)
            {
                Sexualidade = "Masculino";
            }
            else if (radioFemi.Checked)
            {
                Sexualidade = "Feminino";
            }
            else
            {
                MessageBox.Show("Sexualidade não selecionado!", "Faltando informações", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            String FichaPessoal = "FichaPessoal.txt";

            StreamWriter objArquivo = new StreamWriter(FichaPessoal);
            objArquivo.WriteLine("===========================================================");
            objArquivo.WriteLine("                   *Cadastro de Cliente*                  *");
            objArquivo.WriteLine("");
            objArquivo.WriteLine("*Nome: " + textName2.Text);
            objArquivo.WriteLine("*Data de Nascimento: " + textNasci.Text);
            objArquivo.WriteLine("*Sexualidade: " + Sexualidade);
            objArquivo.WriteLine("*CPF: " + textCPF.Text);
            objArquivo.WriteLine("*Endereço: " + textBoxRua.Text);
            objArquivo.WriteLine("*Cidade: " + textCidade.Text);
            objArquivo.WriteLine("*UF: " + textUF.Text);
            objArquivo.WriteLine("Telefone: " + textTelefone.Text);
            objArquivo.WriteLine("Email: " + textEmail.Text);
            objArquivo.WriteLine("");
            objArquivo.WriteLine("Data de criação: " + DateTime.Now);
            objArquivo.WriteLine("===========================================================");
            objArquivo.Close();

            try
            {
                //conexão
                string caminho;
                caminho = ProjetoMusical.Properties.Settings.Default.Database1ConnectionString;
                SqlConnection objconexao = new SqlConnection(caminho);
                objconexao.Open();

                //consulta

                string Genero;

                if (radioMasc.Checked)
                {
                    Genero = "Masculino";
                }
                else
                    Genero = "Feminino";

                string comando;
                comando = "insert into Cliente(Nome, Genero, Data_de_Nascimento, Data_de_Registro, CPF, Cidade, UF, Endereco, Telefone, Email) VALUES ('" + textName2.Text + "', '" + Genero + "', '" + textNasci.Text + "', '" + DateTime.Now + "', '" + textCPF.Text + "', '" + textCidade.Text + "', '" + textUF.Text + "', '" + textBoxRua.Text + "', '" + textTelefone.Text + "', '" + textEmail.Text + "')";
                SqlCommand objcomando = new SqlCommand(comando, objconexao);
                objcomando.ExecuteNonQuery();

                MessageBox.Show("Cadastro feito com êxito!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("OPA! Deu erro! Preste a atenção", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        private void butVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            t1 = new Thread(Abrirjanela);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }
        private void Abrirjanela(object obj)
        {
            Application.Run(new Menu());
        }
    }
    
}

