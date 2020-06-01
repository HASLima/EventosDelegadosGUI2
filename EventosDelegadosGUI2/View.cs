using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosDelegadosGUI2
{
    public class View
    {
        private Model model;
        private Form1 janela;

        public event System.EventHandler UtilizadorClicouEmNovoSalvoConduto;

        public delegate void UtilizadorClicarEmVerificarSalvoConduto();
        public event UtilizadorClicarEmVerificarSalvoConduto UtilizadorClicouEmVerificarSalvoConduto;



        internal View(Model m)
        {
            model = m;
        }

        public void ActivarUI()
        {
            janela = new Form1();
            janela.View = this;

            janela.ShowDialog();
        }

        

        public void CliqueEmNovoSalvoConduto(object origem, EventArgs e) //TODO não precisava dos argumentos pensar se vale a pena manter a título de exemplo
        {
            UtilizadorClicouEmNovoSalvoConduto(origem, e);
        }

        public void CliqueEmVerificarSalvoConduto()
        {
            UtilizadorClicouEmVerificarSalvoConduto();
        }



    }
}
