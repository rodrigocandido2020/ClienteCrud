namespace ClienteCrud
{
    partial class CadastroDeUsuario
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
            this.nomeTxt = new System.Windows.Forms.TextBox();
            this.senhaTxt = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.maskedTextData = new System.Windows.Forms.MaskedTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Salvar = new System.Windows.Forms.Button();
            this.Lbl_Cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.idTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nomeTxt
            // 
            this.nomeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.nomeTxt.Location = new System.Drawing.Point(118, 33);
            this.nomeTxt.Name = "nomeTxt";
            this.nomeTxt.Size = new System.Drawing.Size(192, 20);
            this.nomeTxt.TabIndex = 8;
            this.nomeTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // senhaTxt
            // 
            this.senhaTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.senhaTxt.Location = new System.Drawing.Point(119, 59);
            this.senhaTxt.Name = "senhaTxt";
            this.senhaTxt.Size = new System.Drawing.Size(192, 20);
            this.senhaTxt.TabIndex = 9;
            this.senhaTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.senhaTxt.UseSystemPasswordChar = true;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(0, 0);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 20);
            this.textBox7.TabIndex = 26;
            // 
            // emailTxt
            // 
            this.emailTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.emailTxt.Location = new System.Drawing.Point(119, 91);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(191, 20);
            this.emailTxt.TabIndex = 10;
            this.emailTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maskedTextData
            // 
            this.maskedTextData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.maskedTextData.Location = new System.Drawing.Point(117, 161);
            this.maskedTextData.Mask = "00/00/0000";
            this.maskedTextData.Name = "maskedTextData";
            this.maskedTextData.Size = new System.Drawing.Size(100, 20);
            this.maskedTextData.TabIndex = 11;
            this.maskedTextData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextData.ValidatingType = typeof(System.DateTime);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(118, 126);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(99, 20);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // Lbl_Salvar
            // 
            this.Lbl_Salvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lbl_Salvar.Location = new System.Drawing.Point(12, 201);
            this.Lbl_Salvar.Name = "Lbl_Salvar";
            this.Lbl_Salvar.Size = new System.Drawing.Size(100, 23);
            this.Lbl_Salvar.TabIndex = 13;
            this.Lbl_Salvar.Text = "Salvar";
            this.Lbl_Salvar.UseVisualStyleBackColor = true;
            this.Lbl_Salvar.Click += new System.EventHandler(this.AoclicarEmSalvar);
            // 
            // Lbl_Cancelar
            // 
            this.Lbl_Cancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Lbl_Cancelar.Location = new System.Drawing.Point(129, 201);
            this.Lbl_Cancelar.Name = "Lbl_Cancelar";
            this.Lbl_Cancelar.Size = new System.Drawing.Size(99, 23);
            this.Lbl_Cancelar.TabIndex = 14;
            this.Lbl_Cancelar.Text = "Cancelar";
            this.Lbl_Cancelar.UseVisualStyleBackColor = true;
            this.Lbl_Cancelar.Click += new System.EventHandler(this.AoClicarEmCancelar);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Nome*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Senha*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "E-mail*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Data Criação";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Data Nascimento";
            // 
            // idTxt
            // 
            this.idTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.idTxt.Location = new System.Drawing.Point(118, 7);
            this.idTxt.Name = "idTxt";
            this.idTxt.ReadOnly = true;
            this.idTxt.Size = new System.Drawing.Size(34, 20);
            this.idTxt.TabIndex = 25;
            this.idTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CadastroDeUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 231);
            this.Controls.Add(this.idTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lbl_Cancelar);
            this.Controls.Add(this.Lbl_Salvar);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.maskedTextData);
            this.Controls.Add(this.emailTxt);
            this.Controls.Add(this.senhaTxt);
            this.Controls.Add(this.nomeTxt);
            this.Controls.Add(this.textBox7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CadastroDeUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox nomeTxt;
        private System.Windows.Forms.TextBox senhaTxt;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox emailTxt;
        private System.Windows.Forms.MaskedTextBox maskedTextData;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button Lbl_Salvar;
        private System.Windows.Forms.Button Lbl_Cancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox idTxt;
    }
}