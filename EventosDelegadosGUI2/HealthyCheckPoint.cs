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
            //SalvoCondutoPDF salvoCondutoPDF = new SalvoCondutoPDF("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse gravida ante in augue vulputate, sit amet lacinia quam malesuada. Nam congue enim quis consectetur finibus. Nam dignissim libero varius, scelerisque sapien at, consequat nibh. Integer non lorem et velit cursus tincidunt non eget velit. Duis at luctus odio, ac tempor libero. Sed fringilla volutpat ligula, iaculis rhoncus arcu pellentesque quis. In hac habitasse platea dictumst. Nullam fermentum efficitur vehicula. Aliquam vel diam purus. Praesent volutpat nisi sem, eget ultrices est euismod eu. Pellentesque dapibus, mauris eget posuere luctus, sapien diam varius nisl, et bibendum justo diam sit amet libero. Nullam nec mattis nibh, vitae iaculis libero. Etiam ac molestie ante, a pharetra quam.");

                Controller controller = new Controller();
                controller.IniciarPrograma();
        }
    }
}
