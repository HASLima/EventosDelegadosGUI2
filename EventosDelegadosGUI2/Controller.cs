using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace HealthyCheckpoint
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

            view.UtilizadorClicouEmSubmeter += PrecisoSubmeterSalvoConduto;
            view.UtilizadorClicouEmVerificar += PrecisoVerificarSalvoConduto;
            model.SalvoCondutoCriado += view.InformarSalvoCondutoCriado;
            model.SalvoCondutoVerificado += view.InformarSalvoCondutoVerificado;
            
        }

        public void IniciarPrograma()
        {

                    view.ActivarUI();
      
        }
        
        public void PrecisoSubmeterSalvoConduto(string origem, string destino, bool imprimir)
        {
            model.CriarNovoSalvoConduto(origem, destino, imprimir);
        }

        public void PrecisoVerificarSalvoConduto(IPedidoDeVerificacao pedidoDeVerificacao)
        {
            model.VerificarSalvoConduto(pedidoDeVerificacao);
        }

        


    }
}
