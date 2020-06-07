using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace EventosDelegadosGUI2
{
    public class Model
    {
        private View view;
        private List<SalvoConduto> salvoCondutos;

        public delegate void VerificacaoSalvoConduto(bool encontrado, string origem, string destino, string referencia, bool valido);
        public event VerificacaoSalvoConduto SalvoCondutoVerificado;

        public delegate void CriacaoSalvoConduto(ISalvoConduto salvoConduto);
        public event CriacaoSalvoConduto SalvoCondutoCriado;




        public Model(View v)
        {
            view = v;
            salvoCondutos = new List<SalvoConduto>();
        }

        public int LastIdIssued()
        {
            int max = int.MinValue;
            if (salvoCondutos.Count == 0)
                return -1;
            else
            {
                foreach (SalvoConduto salvoConduto in salvoCondutos)
                {
                    if (salvoConduto.Id > max)
                        max = salvoConduto.Id;
                }
                return max;
            }
        }

        public void CriarNovoSalvoConduto(string origem, string destino, bool imprimir)
        {
            
            SalvoConduto salvoConduto = new SalvoConduto(origem, destino, LastIdIssued());
            SalvoCondutoCriado(salvoConduto);
            if (imprimir)
            {
                CriarPDF(salvoConduto);
            }
            salvoCondutos.Add(salvoConduto);
        }

        public void VerificarSalvoConduto(string referencia, bool print)
        {
            if (salvoCondutos.Exists(x => x.Referencia == referencia))
            {
                SalvoCondutoVerificado(true, salvoCondutos.Find(x => x.Referencia == referencia).Origem, salvoCondutos.Find(x => x.Referencia == referencia).Destino, referencia, salvoCondutos.Find(x => x.Referencia == referencia).Valido);
                if (print)
                {
                    CriarPDF(salvoCondutos.Find(x => x.Referencia == referencia));
                }
            }
            else
                SalvoCondutoVerificado(false, null, null, referencia, false);
        }

        private void CriarPDF(ISalvoConduto salvoConduto)
        {
            _ = new SalvoCondutoPDF(salvoConduto); //TODO falta pedir o local de gravação
        }
    }
}