using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosDelegadosGUI2
{
    //Esta classe pertecence ao componente Model
    class SalvoConduto
    {
        private int id;
        private string origem;
        private string destino;
        private string referencia;
        private bool valido;






        public SalvoConduto(string origem, string destino, int lastIdIssued)
        {   
            Id = lastIdIssued + 1;
            Origem = origem;
            Destino = destino;
            Referencia = DefineReferencia();
            Valido = true;
            System.Windows.Forms.Clipboard.SetText(Referencia);
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Origem
        {
            get { return origem; }
            set { origem = value; }
        }

        public string Destino
        {
            get { return destino; }
            set { destino = value; }
        }

        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        public bool Valido
        {
            get { return valido; }
            set { valido = value; }
        }

        private string DefineReferencia()
        {
            referencia = DateTime.Now.Day.ToString("D2") +
                DateTime.Now.Hour.ToString("D2") +
                DateTime.Now.Minute.ToString("D2") +
                DateTime.Now.Second.ToString("D2");
            switch (DateTime.Now.Month)
            {
                case 1:
                    referencia += "JAN";
                    break;
                case 2:
                    referencia += "FEV";
                    break;
                case 3:
                    referencia += "MAR";
                    break;
                case 4:
                    referencia += "ABR";
                    break;
                case 5:
                    referencia += "MAI";
                    break;
                case 6:
                    referencia += "JUN";
                    break;
                case 7:
                    referencia += "JUL";
                    break;
                case 8:
                    referencia += "AGO";
                    break;
                case 9:
                    referencia += "SET";
                    break;
                case 10:
                    referencia += "OUT";
                    break;
                case 11:
                    referencia += "NOV";
                    break;
                case 12:
                    referencia += "DEC";
                    break;
            }
            referencia += DateTime.Now.Year.ToString("D2") + id.ToString("D8");
            return referencia;
        }

        
    }
}
