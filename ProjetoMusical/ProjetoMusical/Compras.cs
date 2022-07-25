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
using System.IO;
using System.Diagnostics;

namespace ProjetoMusical
{
    public partial class Compras : Form
    {
        Thread t1;

        public Compras()
        {
            InitializeComponent();
        }

        private void butvoltar2_Click(object sender, EventArgs e)
        {
            this.Close();
            t1 = new Thread(Abrirjanela1);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }
        private void Abrirjanela1(object obj)
        {
            Application.Run(new Menu());
        }

        private void butConfirmar_Click(object sender, EventArgs e)
        {
            if (QtdBateria.Text == "")
            {
                MessageBox.Show("Erro! Digite a quantidade de bateria!", "Faltando informações!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                QtdBateria.Focus();
                return;     
            }
            if (QtdPiano.Text == "")
            {
                MessageBox.Show("Erro! Digite a quantidade de piano!", "Faltando informações!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                QtdPiano.Focus();
                return;
            }
            if (QtdSax.Text == "")
            {
                MessageBox.Show("Erro! Digite a quantidade de Saxofone!", "Faltando informações!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                QtdSax.Focus();
                return;
            }
            if (QtdViolão.Text == "")
            {
                MessageBox.Show("Erro! Digite a quantidade de Violão!", "Faltando informações!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                QtdViolão.Focus();
                return;
            }
            if (QtdBaqueta.Text == "")
            {
                MessageBox.Show("Erro! Digite a quantidade de pares de Baquetas!", "Faltando informações!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                QtdBaqueta.Focus();
                return;
            }
            if (QtdClipe.Text == "")
            {
                MessageBox.Show("Erro! Digite a quantidade de Clipe de Partitura!", "Faltando informações!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                QtdClipe.Focus();
                return;
            }
            if (QtdCorda.Text == "")
            {
                MessageBox.Show("Erro! Digite a quantidade de pacote de corda para Violão!", "Faltando informações!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                QtdCorda.Focus();
                return;
            }
            if (QtdKit.Text == "")
            {
                MessageBox.Show("Erro! Digite a quantidade de Kit de Afinação!", "Faltando informações!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                QtdKit.Focus();
                return;
            }

            int qtd1, qtd2, qtd3, qtd4, qtd5, qtd6, qtd7, qtd8;
            double Totalf = 0, Total1 = 0, Total2 = 0, Total3 = 0, Total4 = 0;
            double Total5 = 0, Total6 = 0, Total7 = 0, Total8 = 0;

            try
            {
                qtd1 = int.Parse(QtdBateria.Text);
                qtd2 = int.Parse(QtdPiano.Text);
                qtd3 = int.Parse(QtdSax.Text);
                qtd4 = int.Parse(QtdViolão.Text);

                qtd5 = int.Parse(QtdBaqueta.Text);
                qtd6 = int.Parse(QtdClipe.Text);
                qtd7 = int.Parse(QtdCorda.Text);
                qtd8 = int.Parse(QtdKit.Text);

                Total1 = qtd1 * 1500;
                Total2 = qtd2 * 2500;
                Total3 = qtd3 * 2000;
                Total4 = qtd4 * 750;

                Total5 = qtd5 * 10;
                Total6 = qtd6 * 80;
                Total7 = qtd7 * 25;
                Total8 = qtd8 * 250;

                Totalf = Total1 + Total2 + Total3 + Total4 + Total5 + Total6 + Total7 + Total8;

                Total1.ToString("C2");
                Total2.ToString("C2");
                Total3.ToString("C2");
                Total4.ToString("C2");

                Total5.ToString("C2");
                Total6.ToString("C2");
                Total7.ToString("C2");
                Total8.ToString("C2");
            }
            catch
            {
                MessageBox.Show("Erro! Você digitou algo errado, preste atenção e tente novamente!!", "Algo de errado não está certo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            String NotaFiscal = "Nota_Fiscal.txt";

            StreamWriter objArquivo = new StreamWriter(NotaFiscal);
            objArquivo.WriteLine("===========================================================");
            objArquivo.WriteLine("                         *Nota Fiscal*                     ");
            objArquivo.WriteLine("");
            objArquivo.WriteLine("-Instrumentos-");
            objArquivo.WriteLine("");
            objArquivo.WriteLine("*Bateria: "+QtdBateria.Text);
            objArquivo.WriteLine(">Valor: R$ "+Total1);
            objArquivo.WriteLine("");
            objArquivo.WriteLine("*Piano Vertical: "+QtdPiano.Text);
            objArquivo.WriteLine(">Valor: R$ "+Total2);
            objArquivo.WriteLine("");
            objArquivo.WriteLine("*Saxofone: "+QtdSax.Text);
            objArquivo.WriteLine(">Valor: R$ "+Total3);
            objArquivo.WriteLine("");
            objArquivo.WriteLine("*Violão: "+QtdViolão.Text);
            objArquivo.WriteLine(">Valor: R$ "+Total4);
            objArquivo.WriteLine("");
            objArquivo.WriteLine("-Acessórios-");
            objArquivo.WriteLine("");
            objArquivo.WriteLine("*Par de baquetas: "+QtdBaqueta.Text);
            objArquivo.WriteLine(">Valor: R$ "+Total5);
            objArquivo.WriteLine("");
            objArquivo.WriteLine("*Partitura Clipe para Saxofone: "+QtdClipe.Text);
            objArquivo.WriteLine(">Valor: R$ "+Total6);
            objArquivo.WriteLine("");
            objArquivo.WriteLine("*Pacote de corda para vioão: "+QtdCorda.Text);
            objArquivo.WriteLine(">Valor: R$ "+Total7);
            objArquivo.WriteLine("");
            objArquivo.WriteLine("*Kit de afinação para Piano: "+QtdKit.Text);
            objArquivo.WriteLine(">Valor: R$ "+Total8);
            objArquivo.WriteLine("");
            objArquivo.WriteLine("-----------------------------------------------------------");
            objArquivo.WriteLine("");
            objArquivo.WriteLine("Total a pagar: R$ " + Totalf);
            objArquivo.WriteLine("");
            objArquivo.WriteLine("Data da compra: " + DateTime.Now);
            objArquivo.WriteLine("===========================================================");
            objArquivo.Close();

            MessageBox.Show("Compra feita com êxito! Nota fiscal gerado!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void butCalc_Click(object sender, EventArgs e)
        {
            int qtd1, qtd2, qtd3, qtd4, qtd5, qtd6, qtd7, qtd8;
            double Totalf = 0, Total1 = 0, Total2 = 0, Total3 = 0, Total4 =0;
            double Total5 =0, Total6 = 0, Total7 = 0, Total8 = 0;

            try
            {
                qtd1 = int.Parse(QtdBateria.Text);
                qtd2 = int.Parse(QtdPiano.Text);
                qtd3 = int.Parse(QtdSax.Text);
                qtd4 = int.Parse(QtdViolão.Text);

                qtd5 = int.Parse(QtdBaqueta.Text);
                qtd6 = int.Parse(QtdClipe.Text);
                qtd7 = int.Parse(QtdCorda.Text);
                qtd8 = int.Parse(QtdKit.Text);

                Total1 = qtd1 * 1500;
                Total2 = qtd2 * 2500;
                Total3 = qtd3 * 2000;
                Total4 = qtd4 * 750;

                Total5 = qtd5 * 10;
                Total6 = qtd6 * 90;
                Total7 = qtd7 * 25;
                Total8 = qtd8 * 250;

                Totalf = Total1 + Total2 + Total3 + Total4 + Total5 + Total6 + Total7 + Total8;

                textTotal.Text = Totalf.ToString("C2");

                Total1.ToString("C2");
                Total2.ToString("C2");
                Total3.ToString("C2");
                Total4.ToString("C2");

                Total5.ToString("C2");
                Total6.ToString("C2");
                Total7.ToString("C2");
                Total8.ToString("C2");
            }
            catch
            {
                MessageBox.Show("Erro! Você digitou algo errado, preste atenção e tente novamente!!", "Algo de errado não está certo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butLimpar2_Click(object sender, EventArgs e)
        {
            QtdBateria.Clear();
            QtdPiano.Clear();
            QtdSax.Clear();
            QtdViolão.Clear();
            QtdBaqueta.Clear();
            QtdClipe.Clear();
            QtdCorda.Clear();
            QtdKit.Clear();
        }
    }
}
