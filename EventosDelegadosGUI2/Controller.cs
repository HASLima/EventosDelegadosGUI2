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

            view.UtilizadorClicouEmSubmeter += UtilizadorClicouEmSubmeter;
            view.UtilizadorClicouEmVerificar += UtilizadorClicouEmVerificarSalvoConduto;
            model.SalvoCondutoCriado += view.SalvoCondutoCriado;
            model.SalvoCondutoVerificado += view.SalvoCondutoVerificado;
            
        }

        public void IniciarPrograma()
        {
            view.ActivarUI();
        }
        
        public void UtilizadorClicouEmSubmeter(string origem, string destino)
        {
            model.CriarNovoSalvoConduto(origem, destino);
        }

        public void UtilizadorClicouEmVerificarSalvoConduto(string referencia)
        {
            model.VerificarSalvoConduto(referencia);
        }

        


    }
}
