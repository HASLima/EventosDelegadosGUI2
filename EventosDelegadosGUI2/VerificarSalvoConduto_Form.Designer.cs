namespace EventosDelegadosGUI2
{
    partial class VerificarSalvoConduto_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.referencia_Textbox = new System.Windows.Forms.TextBox();
            this.referencia_Label = new System.Windows.Forms.Label();
            this.verificarSalvoConduto_button = new System.Windows.Forms.Button();
            this.print_checkbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // referencia_Textbox
            // 
            this.referencia_Textbox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.referencia_Textbox.Location = new System.Drawing.Point(90, 5);
            this.referencia_Textbox.Name = "referencia_Textbox";
            this.referencia_Textbox.Size = new System.Drawing.Size(223, 19);
            this.referencia_Textbox.TabIndex = 7;
            this.referencia_Textbox.Tag = "referencia";
            // 
            // referencia_Label
            // 
            this.referencia_Label.AutoSize = true;
            this.referencia_Label.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.referencia_Label.Location = new System.Drawing.Point(12, 9);
            this.referencia_Label.Name = "referencia_Label";
            this.referencia_Label.Size = new System.Drawing.Size(70, 15);
            this.referencia_Label.TabIndex = 6;
            this.referencia_Label.Text = "Referência:";
            // 
            // verificarSalvoConduto_button
            // 
            this.verificarSalvoConduto_button.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verificarSalvoConduto_button.Location = new System.Drawing.Point(15, 51);
            this.verificarSalvoConduto_button.Name = "verificarSalvoConduto_button";
            this.verificarSalvoConduto_button.Size = new System.Drawing.Size(298, 54);
            this.verificarSalvoConduto_button.TabIndex = 8;
            this.verificarSalvoConduto_button.Text = "Verificar Salvo-Conduto";
            this.verificarSalvoConduto_button.UseVisualStyleBackColor = true;
            this.verificarSalvoConduto_button.Click += new System.EventHandler(this.verificarSalvoConduto_button_Click);
            // 
            // print_checkbox
            // 
            this.print_checkbox.AutoSize = true;
            this.print_checkbox.Location = new System.Drawing.Point(15, 28);
            this.print_checkbox.Name = "print_checkbox";
            this.print_checkbox.Size = new System.Drawing.Size(67, 17);
            this.print_checkbox.TabIndex = 9;
            this.print_checkbox.Text = "Imprimir?";
            this.print_checkbox.UseVisualStyleBackColor = true;
            // 
            // VerificarSalvoConduto_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 111);
            this.Controls.Add(this.print_checkbox);
            this.Controls.Add(this.verificarSalvoConduto_button);
            this.Controls.Add(this.referencia_Textbox);
            this.Controls.Add(this.referencia_Label);
            this.Name = "VerificarSalvoConduto_Form";
            this.Text = "VerificarSalvoConduto_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox referencia_Textbox;
        private System.Windows.Forms.Label referencia_Label;
        private System.Windows.Forms.Button verificarSalvoConduto_button;
        private System.Windows.Forms.CheckBox print_checkbox;
    }
}