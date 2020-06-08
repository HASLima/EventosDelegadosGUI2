using System;
using System.Windows.Forms;

namespace HealthyCheckpoint
{
    public partial class Form1 : Form
    {
        View view;

        //public event System.EventHandler UtilizadorClicouEmNovoSalvoConduto;
        public delegate void UtilizadorClicarEmNovoSalvoConduto(object sender, EventArgs e);
        public event UtilizadorClicarEmNovoSalvoConduto UtilizadorClicouEmNovoSalvoConduto;

        public delegate void UtilizadorClicarEmVerificarSalvoConduto(object sender, EventArgs e);
        public event UtilizadorClicarEmVerificarSalvoConduto UtilizadorClicouEmVerificarSalvoConduto;


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
            UtilizadorClicouEmNovoSalvoConduto(sender, e);
        }

        private void verificarSalvoConduto_button_Click(object sender, EventArgs e)
        {
            UtilizadorClicouEmVerificarSalvoConduto(sender, e);
        }
    }
}
