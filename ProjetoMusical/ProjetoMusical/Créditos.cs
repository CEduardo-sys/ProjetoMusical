﻿using System;
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
    public partial class Créditos : Form
    {
        Thread t1;

        public Créditos()
        {
            InitializeComponent();
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
