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
using static EventosDelegadosGUI2.Gdh;

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
        XRect imageRect;
        System.Reflection.Assembly thisExe;
        Stream file;


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

            //Puxar o logo das Entidades Competentes para um stream
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            file = thisExe.GetManifestResourceStream("EventosDelegadosGUI2.Properties.Sem título.png");

            //para o transformar num XImage
            image = XImage.FromStream(file);

            //tracar um rectangulo para ser possivel centrar o logo
            imageRect = new XRect(150, 30, page.Width-300, 100);

            //imprimir o logo
            graphics.DrawRectangle(XBrushes.White, imageRect);
            graphics.DrawImage(image, imageRect.Left, imageRect.Top, imageRect.Width, XUnit.FromMillimeter(15));

            //imprimir o título
            textFormatterTitle.DrawString("Salvo-Conduto", fontTitle, XBrushes.Black, new XRect(50, 100, page.Width - 100, 50));

            //Imprimir as etiquetas Origem, destino e referencia
            textFormatterText.DrawString("Origem: ", fontText, XBrushes.Black, new XRect(50, 200, 100, 25));
            textFormatterText.DrawString("Destino: ", fontText, XBrushes.Black, new XRect(50, 225, 100, 25));
            textFormatterText.DrawString("Referencia: ", fontText, XBrushes.Black, new XRect(50, 250, 100, 25));
            
            //Mudar a font e preencher os campos relativos à origem, destino e referencia
            fontText = new XFont("Lucida Console", 12);
            textFormatterText.DrawString(salvoConduto.Origem, fontText, XBrushes.Black, new XRect(175, 200, page.Width-(175+50), 25));
            textFormatterText.DrawString(salvoConduto.Destino, fontText, XBrushes.Black, new XRect(175, 225, page.Width - (175 + 50), 25));
            textFormatterText.DrawString(salvoConduto.Referencia, fontText, XBrushes.Black, new XRect(175, 250, page.Width - (175 + 50), 25));

            //Voltar à font original e imprimir texto legal
            fontText = new XFont("Arial", 10);
            textFormatterText.DrawString("Este documento autoriza o seu portador a deslocar-se da localidade indicada em Origem até à localidade indicada em Destino. A qualquer momento este documento poderá ser revogado pelas Entidades Competentes. O portador pode contactar as Entidades Competentes a fim de verificar a validade do Salvo-Conduto, indicando a sua Referência.", fontText, XBrushes.Gray, new XRect(50, 300, page.Width - 100, page.Height-(300+50)));

            //Imprimir a data e hora em que foi impresso
            fontText = new XFont("Arial", 8);
            textFormatterText.DrawString(String.Format("Impresso em {0}", ActualGdh()), fontText, XBrushes.Gray, new XRect(page.Width - 150, page.Height - 30, 100, 20)); //TODO implementar o metodo GDH

            //Gravar o ficheiro
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
