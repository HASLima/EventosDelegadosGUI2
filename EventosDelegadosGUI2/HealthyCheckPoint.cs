using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventosDelegadosGUI2
{
    static class HealthyCheckPoint
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //---ESTE CÓDIGO FOI CRIADO PELO VISUAL STUDIO
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            Controller controller = new Controller();
            controller.IniciarPrograma();
        }
    }
}
