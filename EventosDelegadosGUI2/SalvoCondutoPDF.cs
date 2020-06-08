using PdfSharp.Drawing;
using PdfSharp.Drawing.BarCodes;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace HealthyCheckpoint
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
            imageRect = new XRect(150, 30, page.Width - 300, 100);

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
            textFormatterText.DrawString(salvoConduto.Origem, fontText, XBrushes.Black, new XRect(175, 200, page.Width - (175 + 50), 25));
            textFormatterText.DrawString(salvoConduto.Destino, fontText, XBrushes.Black, new XRect(175, 225, page.Width - (175 + 50), 25));
            textFormatterText.DrawString(salvoConduto.Referencia, fontText, XBrushes.Black, new XRect(175, 250, page.Width - (175 + 50), 25));

            //Mudar a font e imprimir o codigo de barras
            fontText = new XFont("Code 128", 40);
            textFormatterText.Alignment = (XParagraphAlignment)2;
            textFormatterText.DrawString(get128Code(salvoConduto.Referencia), fontText, XBrushes.Black, new XRect(50, 425, page.Width-100, 25));

            //Voltar à font original e imprimir texto legal
            fontText = new XFont("Arial", 10);
            textFormatterText.Alignment = (XParagraphAlignment)4;
            textFormatterText.DrawString("Este documento autoriza o seu portador a deslocar-se da localidade indicada em Origem até à localidade indicada em Destino. A qualquer momento este documento poderá ser revogado pelas Entidades Competentes. O portador pode contactar as Entidades Competentes a fim de verificar a validade do Salvo-Conduto, indicando a sua Referência.", fontText, XBrushes.Gray, new XRect(50, 300, page.Width - 100, page.Height - (300 + 50)));

            //Imprimir a data e hora em que foi impresso
            fontText = new XFont("Arial", 8);
            textFormatterText.DrawString(String.Format("Impresso em {0}", Gdh.ActualGdh()), fontText, XBrushes.Gray, new XRect(page.Width - 150, page.Height - 30, 100, 20)); //TODO implementar o metodo GDH

            //Gravar o ficheiro
            string fileName = String.Format("salvoConduto{0}.pdf", salvoConduto.Referencia);
            Debug.WriteLine("fileName antes do SaveDoc: " + fileName);
            fileName = SaveDoc(fileName);
            Debug.WriteLine("fileName depois do SaveDoc: " + fileName);
            System.Diagnostics.Process.Start(fileName);

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

        public bool IsFileLocked(string fileName)
        {
            var stream = (FileStream)null;
            FileInfo file = new FileInfo(fileName);

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (System.IO.FileNotFoundException)
            {
                return false;
            }
            catch (System.IO.IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

        public string SaveDoc(string fileName)
        {
            while (IsFileLocked(fileName))
            {
                if (fileName.Substring(fileName.Length - 5, 1) == ")")
                {
                    int start = fileName.IndexOf('(') + 1;
                    int end = fileName.IndexOf(')') - 1;
                    int value;
                    Int32.TryParse(fileName.Substring(start, end - start + 1), out value);
                    Debug.WriteLine(value);
                    fileName = fileName.Substring(0, start - 1) + "(" + (value + 1) + ").pdf";
                }
                else
                {
                    fileName = fileName.Substring(0, fileName.Length - 4) + "(2).pdf";
                }
            }
            doc.Save(fileName);
            return (fileName);
        }

        private string get128Code(string text)
        {
            string code;
            int value = 104;
            int i = 0;
            int tmp;
            foreach (char letra in text)
            {
                i++;
                value += (Convert.ToInt32(letra) - 32) * i;
            }
            value %= 103;
            value += 32;
            if (value > 126)
            {
                value += 68;
            }
            code = "Ì" + text;
            Debug.WriteLine((char)value + " " + value);
            code += ((char)value).ToString();
            code.Append((char)value);
            code += "Î";
            Debug.WriteLine(code);
            return code;
        }
    }
}
