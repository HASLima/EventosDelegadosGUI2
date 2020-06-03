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
    //Esta class pertence à View
{
    public partial class VerificarSalvoConduto_Form : Form
    {
        View view;


        public VerificarSalvoConduto_Form()
        {
            InitializeComponent();
        }

        public View View
        {
            get { return view; }
            set { view = value; }
        }

        private void verificarSalvoConduto_button_Click(object sender, EventArgs e)
        {
            view.CliqueEmVerificar(referencia_Textbox.Text);
            Close();
        }
    }
}
