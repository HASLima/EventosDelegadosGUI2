namespace HealthyCheckpoint
{
    partial class NovoSalvoConduto_Form
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
            this.submeter_button = new System.Windows.Forms.Button();
            this.origem_Label = new System.Windows.Forms.Label();
            this.origem_Textbox = new System.Windows.Forms.TextBox();
            this.destino_Textbox = new System.Windows.Forms.TextBox();
            this.destino_Label = new System.Windows.Forms.Label();
            this.print_checkbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // submeter_button
            // 
            this.submeter_button.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submeter_button.Location = new System.Drawing.Point(319, 5);
            this.submeter_button.Name = "submeter_button";
            this.submeter_button.Size = new System.Drawing.Size(150, 65);
            this.submeter_button.TabIndex = 4;
            this.submeter_button.Text = "Submeter";
            this.submeter_button.UseVisualStyleBackColor = true;
            this.submeter_button.Click += new System.EventHandler(this.submeter_button_Click);
            // 
            // origem_Label
            // 
            this.origem_Label.AutoSize = true;
            this.origem_Label.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.origem_Label.Location = new System.Drawing.Point(12, 9);
            this.origem_Label.Name = "origem_Label";
            this.origem_Label.Size = new System.Drawing.Size(51, 15);
            this.origem_Label.TabIndex = 2;
            this.origem_Label.Text = "Origem:";
            // 
            // origem_Textbox
            // 
            this.origem_Textbox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.origem_Textbox.Location = new System.Drawing.Point(90, 5);
            this.origem_Textbox.Name = "origem_Textbox";
            this.origem_Textbox.Size = new System.Drawing.Size(223, 19);
            this.origem_Textbox.TabIndex = 1;
            this.origem_Textbox.Tag = "origem";
            // 
            // destino_Textbox
            // 
            this.destino_Textbox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destino_Textbox.Location = new System.Drawing.Point(90, 30);
            this.destino_Textbox.Name = "destino_Textbox";
            this.destino_Textbox.Size = new System.Drawing.Size(223, 19);
            this.destino_Textbox.TabIndex = 2;
            this.destino_Textbox.Tag = "destino";
            // 
            // destino_Label
            // 
            this.destino_Label.AutoSize = true;
            this.destino_Label.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destino_Label.Location = new System.Drawing.Point(12, 34);
            this.destino_Label.Name = "destino_Label";
            this.destino_Label.Size = new System.Drawing.Size(53, 15);
            this.destino_Label.TabIndex = 4;
            this.destino_Label.Text = "Destino:";
            // 
            // print_checkbox
            // 
            this.print_checkbox.AutoSize = true;
            this.print_checkbox.Location = new System.Drawing.Point(15, 53);
            this.print_checkbox.Name = "print_checkbox";
            this.print_checkbox.Size = new System.Drawing.Size(67, 17);
            this.print_checkbox.TabIndex = 3;
            this.print_checkbox.Text = "Imprimir?";
            this.print_checkbox.UseVisualStyleBackColor = true;
            // 
            // NovoSalvoConduto_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 79);
            this.Controls.Add(this.print_checkbox);
            this.Controls.Add(this.destino_Textbox);
            this.Controls.Add(this.destino_Label);
            this.Controls.Add(this.origem_Textbox);
            this.Controls.Add(this.origem_Label);
            this.Controls.Add(this.submeter_button);
            this.Name = "NovoSalvoConduto_Form";
            this.Text = "NovoSalvoConduto_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submeter_button;
        private System.Windows.Forms.Label origem_Label;
        private System.Windows.Forms.TextBox origem_Textbox;
        private System.Windows.Forms.TextBox destino_Textbox;
        private System.Windows.Forms.Label destino_Label;
        private System.Windows.Forms.CheckBox print_checkbox;
    }
}