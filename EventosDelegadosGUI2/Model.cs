using System.Collections.Generic;

namespace HealthyCheckpoint
{
    public class Model
    {
        private View view;
        private List<SalvoConduto> salvoCondutos;

        public delegate void VerificacaoSalvoConduto(bool encontrado, string origem, string destino, string referencia, bool valido, string caminho = null);
        public event VerificacaoSalvoConduto SalvoCondutoVerificado;

        public delegate void CriacaoSalvoConduto(ISalvoConduto salvoConduto, string caminho = null);
        public event CriacaoSalvoConduto SalvoCondutoCriado;

        public delegate void CriacaoPDF(string caminho);
        public event CriacaoPDF FoiCriadoPDF;

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
            string caminho;

            SalvoConduto salvoConduto = new SalvoConduto(origem, destino, LastIdIssued());
            if (imprimir)
            {
                caminho = CriarPDF(salvoConduto);
                SalvoCondutoCriado(salvoConduto, caminho);
            }
            else
                SalvoCondutoCriado(salvoConduto);
            salvoCondutos.Add(salvoConduto);
        }

        public void VerificarSalvoConduto(IPedidoDeVerificacao pedidoDeVerificacao)
        {
            string caminho;
            if (salvoCondutos.Exists(x => x.Referencia == pedidoDeVerificacao.Referencia))
            {
                
                if (pedidoDeVerificacao.Imprimir)
                {
                    caminho = CriarPDF(salvoCondutos.Find(x => x.Referencia == pedidoDeVerificacao.Referencia));
                    SalvoCondutoVerificado(true, salvoCondutos.Find(x => x.Referencia == pedidoDeVerificacao.Referencia).Origem, salvoCondutos.Find(x => x.Referencia == pedidoDeVerificacao.Referencia).Destino, pedidoDeVerificacao.Referencia, salvoCondutos.Find(x => x.Referencia == pedidoDeVerificacao.Referencia).Valido, caminho);
                }
                else
                {
                    SalvoCondutoVerificado(true, salvoCondutos.Find(x => x.Referencia == pedidoDeVerificacao.Referencia).Origem, salvoCondutos.Find(x => x.Referencia == pedidoDeVerificacao.Referencia).Destino, pedidoDeVerificacao.Referencia, salvoCondutos.Find(x => x.Referencia == pedidoDeVerificacao.Referencia).Valido);
                }
                
            }
            else
                SalvoCondutoVerificado(false, null, null, pedidoDeVerificacao.Referencia, false);
        }

        private string CriarPDF(ISalvoConduto salvoConduto)
        {
            SalvoCondutoPDF salvoCondutoPDF = new SalvoCondutoPDF(salvoConduto);
            return salvoCondutoPDF.FileName;
        }

        private void CriadoPDF(string caminho)
        {
            FoiCriadoPDF(caminho);
        }
    }

    public interface ISalvoConduto
    {
        string Origem { get; }
        string Destino { get; }
        string Referencia { get; }
        bool Valido { get; }
    }
}