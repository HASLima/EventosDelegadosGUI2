using System;
using System.Windows.Forms;

namespace HealthyCheckpoint
//Esta class pertence à View
{
    public partial class VerificarSalvoConduto_Form : Form, IPedidoDeVerificacao
    {
        View view;


        public VerificarSalvoConduto_Form()
        {
            InitializeComponent();
        }

        public View View
        {
            get { return view; }
            set { view = value; }
        }

        public string Referencia
        {
            get { return referencia_Textbox.Text; }
        }

        public bool Imprimir
        {
            get { return print_checkbox.Checked; }
        }

        private void verificarSalvoConduto_button_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarDados();
                view.CliqueEmVerificar(this);
                Close();
            }
            catch (ExceptionFaltaDados ex)
            {
                DialogResult caixa;
                caixa = System.Windows.Forms.MessageBox.Show("Deixou o campo " + ex.campo + " por preencher.\nO valor em branco não é válido.\n Prima Cancelar para fechar a janela e voltar ao menu anterior ou Repetir para inserir os dados em falta", "Ooops", System.Windows.Forms.MessageBoxButtons.RetryCancel, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                if (caixa == DialogResult.Cancel)
                    ex.form.Close();
            }
        }

        private void ValidarDados()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox && control.Text.Length == 0)
                    throw new ExceptionFaltaDados(control.Tag.ToString(), this);
            }
            //TODO implementar um sistema que verifique se o texto da origem e/ou destino corresponde a algum dos concelhos ou freguesias de Portugal e, não correspondendo, lançar uma excepção apropriada
        }
    }

    public interface IPedidoDeVerificacao
    {
        string Referencia { get; }
        bool Imprimir { get; }
    }
}
