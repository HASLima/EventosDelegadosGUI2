using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventosDelegadosGUI2
    //Esta class pertence à View
{
    public partial class VerificarSalvoConduto_Form : Form
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

        private void verificarSalvoConduto_button_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarDados();
                view.CliqueEmVerificar(referencia_Textbox.Text);
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
