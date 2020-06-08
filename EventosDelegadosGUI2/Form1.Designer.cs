namespace HealthyCheckpoint
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.novoSalvoConduto_button = new System.Windows.Forms.Button();
            this.verificarSalvoConduto_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // novoSalvoConduto_button
            // 
            this.novoSalvoConduto_button.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.novoSalvoConduto_button.Location = new System.Drawing.Point(12, 12);
            this.novoSalvoConduto_button.Name = "novoSalvoConduto_button";
            this.novoSalvoConduto_button.Size = new System.Drawing.Size(150, 54);
            this.novoSalvoConduto_button.TabIndex = 0;
            this.novoSalvoConduto_button.Text = "Novo Salvo-Conduto";
            this.novoSalvoConduto_button.UseVisualStyleBackColor = true;
            this.novoSalvoConduto_button.Click += new System.EventHandler(this.novoSalvoConduto_button_Click);
            // 
            // verificarSalvoConduto_button
            // 
            this.verificarSalvoConduto_button.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verificarSalvoConduto_button.Location = new System.Drawing.Point(12, 72);
            this.verificarSalvoConduto_button.Name = "verificarSalvoConduto_button";
            this.verificarSalvoConduto_button.Size = new System.Drawing.Size(150, 54);
            this.verificarSalvoConduto_button.TabIndex = 1;
            this.verificarSalvoConduto_button.Text = "Verificar Salvo-Conduto";
            this.verificarSalvoConduto_button.UseVisualStyleBackColor = true;
            this.verificarSalvoConduto_button.Click += new System.EventHandler(this.verificarSalvoConduto_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 139);
            this.Controls.Add(this.verificarSalvoConduto_button);
            this.Controls.Add(this.novoSalvoConduto_button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button novoSalvoConduto_button;
        private System.Windows.Forms.Button verificarSalvoConduto_button;
    }
}

