using System.Collections.Generic;

namespace HealthyCheckpoint
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

        public void VerificarSalvoConduto(IPedidoDeVerificacao pedidoDeVerificacao)
        {
            if (salvoCondutos.Exists(x => x.Referencia == pedidoDeVerificacao.Referencia))
            {
                SalvoCondutoVerificado(true, salvoCondutos.Find(x => x.Referencia == pedidoDeVerificacao.Referencia).Origem, salvoCondutos.Find(x => x.Referencia == pedidoDeVerificacao.Referencia).Destino, pedidoDeVerificacao.Referencia, salvoCondutos.Find(x => x.Referencia == pedidoDeVerificacao.Referencia).Valido);
                if (pedidoDeVerificacao.Imprimir)
                {
                    CriarPDF(salvoCondutos.Find(x => x.Referencia == pedidoDeVerificacao.Referencia));
                }
            }
            else
                SalvoCondutoVerificado(false, null, null, pedidoDeVerificacao.Referencia, false);
        }

        private void CriarPDF(ISalvoConduto salvoConduto)
        {
            _ = new SalvoCondutoPDF(salvoConduto);
        }
    }
}