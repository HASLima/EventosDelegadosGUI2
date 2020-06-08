using System;
using System.Windows.Forms;

namespace HealthyCheckpoint
{
    public partial class NovoSalvoConduto_Form : Form
    {
        View view;



        public NovoSalvoConduto_Form()
        {

            InitializeComponent();
        }

        public View View
        {
            get { return view; }
            set { view = value; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void submeter_button_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarDados();
                view.CliqueEmSubmeter(origem_Textbox.Text, destino_Textbox.Text, print_checkbox.Checked);
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
}
