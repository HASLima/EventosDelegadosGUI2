﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventosDelegadosGUI2
{
    public partial class NovoSalvoConduto_Form : Form
    {
        View view;



        public NovoSalvoConduto_Form()
        {
            InitializeComponent();
        }

        public View View
        {
            get { return view; }
            set { view = value; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void submeter_button_Click(object sender, EventArgs e)
        {
            view.CliqueEmSubmeter(origem_Textbox.Text, destino_Textbox.Text);
            Close();
        }
    }
}