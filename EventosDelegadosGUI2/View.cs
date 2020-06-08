using System;

namespace HealthyCheckpoint
{
    public class View
    {

        private Model model;
        private Form1 janela;




        public delegate void UtilizadorClicarEmSubmeter(string origem, string destino, bool imprimir);
        public event UtilizadorClicarEmSubmeter UtilizadorClicouEmSubmeter;

        public delegate void UtilizadorClicarEmVerificar(IPedidoDeVerificacao pedidoDeVerificacao);
        public event UtilizadorClicarEmVerificar UtilizadorClicouEmVerificar;




        internal View(Model m)
        {
            model = m;


        }

        public void ActivarUI()
        {
            janela = new Form1();
            janela.View = this;

            janela.UtilizadorClicouEmNovoSalvoConduto += AbrirJanelaNovoSalvoConduto;
            janela.UtilizadorClicouEmVerificarSalvoConduto += AbrirJanelaVerificarSalvoConduto;

            janela.ShowDialog();

        }

        public void AbrirJanelaNovoSalvoConduto(object fonte, System.EventArgs args)
        {
            NovoSalvoConduto_Form novoSalvoConduto_Form = new NovoSalvoConduto_Form();
            novoSalvoConduto_Form.View = this;
            novoSalvoConduto_Form.ShowDialog();
        }

        public void AbrirJanelaVerificarSalvoConduto(object fonte, System.EventArgs args)
        {
            VerificarSalvoConduto_Form verificarSalvoConduto_Form = new VerificarSalvoConduto_Form();
            verificarSalvoConduto_Form.View = this;
            verificarSalvoConduto_Form.ShowDialog();
        }

        public void CliqueEmSubmeter(string origem, string destino, bool imprimir)
        {
            UtilizadorClicouEmSubmeter(origem, destino, imprimir);
        }

        public void CliqueEmVerificar(IPedidoDeVerificacao pedidoDeVerificacao)
        {
            UtilizadorClicouEmVerificar(pedidoDeVerificacao);
        }

        public void InformarSalvoCondutoVerificado(bool encontrado, string origem, string destino, string referencia, bool valido, string caminho)
        {
            if (encontrado)
            {
                if (valido)
                    System.Windows.Forms.MessageBox.Show(String.Format("Origem: {0}\nDestino: {1}\nVÁLIDO", origem, destino), "Salvo-Conduto Válido encontrado");
                else
                    System.Windows.Forms.MessageBox.Show(String.Format("Origem: {0}\nDestino: {1}\nNÃO VÁLIDO", origem, destino), "Salvo-Conduto NÃO Válido encontrado");
                if (caminho != null)
                {
                    System.Diagnostics.Process.Start(caminho);
                }
            }
            else
                System.Windows.Forms.MessageBox.Show(String.Format("A referência {0} não consta no sistema!", referencia), "Salvo-Conduto NÃO encontrado");
        }

        public void InformarSalvoCondutoCriado(ISalvoConduto salvoConduto, string caminho)
        {
            System.Windows.Forms.MessageBox.Show(String.Format("Foi registado o Salvo-Conduto!\nOrigem: {0}\nDestino: {1}\nReferencia: {2}", salvoConduto.Origem, salvoConduto.Destino, salvoConduto.Referencia), "Novo Registo");
            if (caminho != null)
            {
                System.Diagnostics.Process.Start(caminho);
            }
        }



    }
}
