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

        public delegate void CriacaoSalvoConduto(string origem, string destino, string referencia);
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

        public void CriarNovoSalvoConduto(string origem, string destino)
        {
            
            SalvoConduto salvoConduto = new SalvoConduto(origem, destino, LastIdIssued());
            SalvoCondutoCriado(salvoConduto.Origem, salvoConduto.Destino, salvoConduto.Referencia);
            salvoCondutos.Add(salvoConduto);
        }

        public void VerificarSalvoConduto(string referencia)
        {
            if (salvoCondutos.Exists(x => x.Referencia == referencia))
                SalvoCondutoVerificado(true, salvoCondutos.Find(x => x.Referencia == referencia).Origem, salvoCondutos.Find(x => x.Referencia == referencia).Destino, referencia, salvoCondutos.Find(x => x.Referencia == referencia).Valido);
            else
                SalvoCondutoVerificado(false, null, null, referencia, false);
        } 
    }
}