using System;
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
    public partial class Form1 : Form
    {
        View view;
        public Form1()
        {
            InitializeComponent();
        }

        public View View
        {
            get { return view; }
            set { view = value; }
        }

        

        private void novoSalvoConduto_button_Click(object sender, EventArgs e)
        {
            view.CliqueEmNovoSalvoConduto(sender, e); //TODO os argumentos não são necessários. Pensar se vale a pena manter os argumentos como exemplo.
        }

        private void verificarSalvoConduto_button_Click(object sender, EventArgs e)
        {
            
        }
    }
}
