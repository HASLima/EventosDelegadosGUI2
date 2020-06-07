using EventosDelegadosGUI2.Properties;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosDelegadosGUI2
{
    class SalvoCondutoPDF
    {
        PdfDocument doc;
        PdfPage page;
        XGraphics graphics;
        XTextFormatter textFormatterText;
        XTextFormatter textFormatterTitle;
        XFont fontText;
        XFont fontTitle;
        XImage image;

        public SalvoCondutoPDF()
        {
            doc = new PdfDocument();
            page = doc.AddPage();
            graphics = XGraphics.FromPdfPage(page);
            textFormatterText = new XTextFormatter(graphics);
            fontText = new XFont("Arial", 12);
        }

        public SalvoCondutoPDF(ISalvoConduto salvoConduto)
        {
            doc = new PdfDocument();
            page = doc.AddPage();
            page.Size = (PdfSharp.PageSize)6;
            graphics = XGraphics.FromPdfPage(page);
            textFormatterText = new XTextFormatter(graphics);
            textFormatterText.Alignment = (XParagraphAlignment)4;
            textFormatterTitle = new XTextFormatter(graphics);
            textFormatterTitle.Alignment = (XParagraphAlignment)2;
            fontText = new XFont("Arial", 12);
            fontTitle = new XFont("Arial", 30);


            System.Reflection.Assembly thisExe = System.Reflection.Assembly.GetExecutingAssembly();

            System.IO.Stream file = null;

            string[] caminhos =
            {
                "EventosDelegadosGUI2.Properties.Resources.resources.entidadesCompetentes",
                "EventosDelegadosGUI2.Properties.Resources.entidadesCompetentes",
                "EventosDelegadosGUI2.Properties.Resources.resources.Sem título.png",
                "EventosDelegadosGUI2.Properties.Resources.Sem título.png",
                "EventosDelegadosGUI2.Properties.Sem título.png"
            };

            for (int i = 0; file == null && i < caminhos.Length; i++)
            {
                file = thisExe.GetManifestResourceStream(caminhos[i]);
            }
            image = XImage.FromStream(file);

            graphics.DrawImage(image, 50, 0, 100, ResizeHeight(ref image, 100));
            textFormatterTitle.DrawString("Salvo-Conduto", fontTitle, XBrushes.Black, new XRect(50, 100, page.Width - 100, 50));
            textFormatterText.DrawString("Origem: ", fontText, XBrushes.Black, new XRect(50, 200, 100, 25));
            textFormatterText.DrawString("Destino: ", fontText, XBrushes.Black, new XRect(50, 225, 100, 25));
            textFormatterText.DrawString("Referencia: ", fontText, XBrushes.Black, new XRect(50, 250, 100, 25));
            fontText = new XFont("Lucida Console", 12);
            textFormatterText.DrawString(salvoConduto.Origem, fontText, XBrushes.Black, new XRect(175, 200, page.Width-(175+50), 25));
            textFormatterText.DrawString(salvoConduto.Destino, fontText, XBrushes.Black, new XRect(175, 225, page.Width - (175 + 50), 25));
            textFormatterText.DrawString(salvoConduto.Referencia, fontText, XBrushes.Black, new XRect(175, 250, page.Width - (175 + 50), 25));
            fontText = new XFont("Arial", 12);

            textFormatterText.DrawString("Este documento autoriza o seu portador a deslocar-se da localidade indicada em Origem até à localidade indicada em Destino. A qualquer momento este documento poderá ser revogado pelas Entidades Competentes. O portador pode contactar as Entidades Competentes a fim de verificar a validade do Salvo-Conduto, indicando a sua Referência.", fontText, XBrushes.Gray, new XRect(50, 300, page.Width - 100, page.Height-(300+50)));

            System.Windows.Forms.MessageBox.Show(String.Format("Height in Point: {0}, Height in Pixel: {1}\nWidth in Point: {2}, Width in Pixel: {3}", image.PointHeight, image.PixelHeight, image.PointWidth, image.PixelWidth));

            
            doc.Save("salvoCOndutoPDF.pdf"); //TODO o nome do ficheiro deve ser relevante
            System.Diagnostics.Process.Start("salvoCOndutoPDF.pdf");
        }

        public double ResizeHeight(ref XImage image, double newHeightSize) //given an image and a new point height size it returns the new  point width size so that the proportion is not altered
        {
            double resizeFactor = newHeightSize / image.PointHeight;
            return image.PointWidth * resizeFactor;
        }

        public double ResizeWidth(ref XImage image, double newWidthSize) //given an image and a new point height size it returns the new  point width size so that the proportion is not altered
        {
            double resizeFactor = newWidthSize / image.PointWidth;
            return image.PointHeight * resizeFactor;
        }
    }
}
