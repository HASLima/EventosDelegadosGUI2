using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosDelegadosGUI2
{
    class Gdh
    {
        public static string ActualGdh()
        {
            string gdh;
            gdh = DateTime.Now.Day.ToString("D2") +
                DateTime.Now.Hour.ToString("D2") +
                DateTime.Now.Minute.ToString("D2");
            switch (DateTime.Now.Month)
            {
                case 1:
                    gdh += "JAN";
                    break;
                case 2:
                    gdh += "FEV";
                    break;
                case 3:
                    gdh += "MAR";
                    break;
                case 4:
                    gdh += "ABR";
                    break;
                case 5:
                    gdh += "MAI";
                    break;
                case 6:
                    gdh += "JUN";
                    break;
                case 7:
                    gdh += "JUL";
                    break;
                case 8:
                    gdh += "AGO";
                    break;
                case 9:
                    gdh += "SET";
                    break;
                case 10:
                    gdh += "OUT";
                    break;
                case 11:
                    gdh += "NOV";
                    break;
                case 12:
                    gdh += "DEC";
                    break;
            }
            gdh += DateTime.Now.Year.ToString("D2").Substring(2);

            return gdh;
        }
    }
}
