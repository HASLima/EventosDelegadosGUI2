using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace EventosDelegadosGUI2
{
    class Controller
    {
        Model model;
        View view;

        public delegate void ActivacaoUI(object origem);
        public event ActivacaoUI ActivarUI;

        public Controller()
        {
            view = new View(model);
            model = new Model(view);

            view.UtilizadorClicouEmNovoSalvoConduto += UtilizadorClicouEmNovoSalvoConduto;
        }

        public void IniciarPrograma()
        {
            view.ActivarUI();
        }

        public void UtilizadorClicouEmNovoSalvoConduto(object fonte, System.EventArgs args)
        {
            //Implementar...
            //model.CriarNovoSalvoConduto();
            NovoSalvoConduto_Form novoSalvoConduto_Form = new NovoSalvoConduto_Form();
            novoSalvoConduto_Form.View = view;

            novoSalvoConduto_Form.ShowDialog();
        }


    }
}
