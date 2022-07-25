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


namespace ProjetoMusical
{
    public partial class Menu : Form
    {
        Thread t1;
        Thread t2;
        Thread t3;
        Thread t4;

        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                this.Close();
                t1 = new Thread(Abrirjanela1);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            }
        }
        private void Abrirjanela1(object obj)
        {
            Application.Run(new CadastroPessoal());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                this.Close();
                t2 = new Thread(Abrirjanela2);
                t2.SetApartmentState(ApartmentState.STA);
                t2.Start();
            }
        }
        private void Abrirjanela2(object obj)
        {
            Application.Run(new Compras());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                this.Close();
                t3 = new Thread(Abrirjanela3);
                t3.SetApartmentState(ApartmentState.STA);
                t3.Start();
            }
        }
        private void Abrirjanela3(object obj)
        {
            Application.Run(new Login());
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void butlook1_Click(object sender, EventArgs e)
        {
            FichaAnderson objAnderson1;

            objAnderson1 = new FichaAnderson();

            objAnderson1.Show();

        }

        private void butlook2_Click(object sender, EventArgs e)
        {
            FichaCássia objcassia1;

            objcassia1 = new FichaCássia();

            objcassia1.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'database1DataSet2.Cliente'. Você pode movê-la ou removê-la conforme necessário.
            this.clienteTableAdapter1.Fill(this.database1DataSet2.Cliente);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonFuncionarios_Click(object sender, EventArgs e)
        {
            /*    {
                      this.Close();
                      t4 = new Thread(Abrirjanela4);
                      t4.SetApartmentState(ApartmentState.STA);
                      t4.Start();
                  }
              }
              private void Abrirjanela4(object obj)
              {
                  Application.Run(new Funcionarios());
              } */

            Funcionarios objconsulta;

            objconsulta = new Funcionarios();
            objconsulta.Show();
        }

        private void butSobre_Click(object sender, EventArgs e)
        {

            Créditos objcolsulta;
            objcolsulta = new Créditos();
            objcolsulta.Show();
        }

        

    }
    }

