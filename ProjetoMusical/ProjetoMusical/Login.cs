using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace ProjetoMusical
{
    public partial class Login : Form
    {
        Thread t1;

        public Login()
        {
            InitializeComponent();
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            if (textName.Text == "")
            {
                MessageBox.Show("Erro! Digite o Nome de usuário!", "Faltando informações!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textName.Focus();
                return;
            }
            if (textSenha.Text == "")
            {
                MessageBox.Show("Erro! Digite a senha!", "Faltando informações!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textSenha.Focus();
            }
         /*   else
            {
                MessageBox.Show("Erro! Senha incorreta!", "Informações incorretas!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textSenha.Clear();
                textSenha.Focus();
            }
         */
            try
            {
                //Conexão
                string caminho;
                caminho = ProjetoMusical.Properties.Settings.Default.Database1ConnectionString;
                SqlConnection objconexao = new SqlConnection(caminho);
                objconexao.Open();

                //Consulta
                string comando;
                comando = "select count(*) from Funcionarios where Nome = '" + textName.Text + "' and Senha = '" + textSenha.Text + "' ";
                SqlCommand objcomando = new SqlCommand(comando, objconexao);
                if ( (int) objcomando.ExecuteScalar() > 0 )
                {
                    this.Close();
                    t1 = new Thread(Abrirjanela);
                    t1.SetApartmentState(ApartmentState.STA);
                    t1.Start();

                    MessageBox.Show("Seja bem-vindo! " +textName.Text, "Welcome!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Login ou senha incorretos!");
                }
            }
            catch
            {
                MessageBox.Show("Deu Erro, tente novamente!");
            }
        }

        private void Abrirjanela(object obj)
        {
            Application.Run(new Menu());
        }

        
    }
}
