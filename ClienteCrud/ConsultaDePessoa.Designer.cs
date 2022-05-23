namespace ClienteCrud
{
    partial class ConsultaDePessoa
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
            this.Lbl_Ok = new System.Windows.Forms.Button();
            this.Lbl_Cancelar = new System.Windows.Forms.Button();
            this.Lbl_Adicionar = new System.Windows.Forms.Button();
            this.Llb_Editar = new System.Windows.Forms.Button();
            this.Lbl_Remover = new System.Windows.Forms.Button();
            this.listaClienteGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.listaClienteGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Ok
            // 
            this.Lbl_Ok.Location = new System.Drawing.Point(12, 314);
            this.Lbl_Ok.Name = "Lbl_Ok";
            this.Lbl_Ok.Size = new System.Drawing.Size(71, 25);
            this.Lbl_Ok.TabIndex = 0;
            this.Lbl_Ok.Text = "Ok";
            this.Lbl_Ok.UseVisualStyleBackColor = true;
            // 
            // Lbl_Cancelar
            // 
            this.Lbl_Cancelar.Location = new System.Drawing.Point(89, 314);
            this.Lbl_Cancelar.Name = "Lbl_Cancelar";
            this.Lbl_Cancelar.Size = new System.Drawing.Size(65, 25);
            this.Lbl_Cancelar.TabIndex = 1;
            this.Lbl_Cancelar.Text = "Cancelar";
            this.Lbl_Cancelar.UseVisualStyleBackColor = true;
            this.Lbl_Cancelar.Click += new System.EventHandler(this.Lbl_Cancelar_Click);
            // 
            // Lbl_Adicionar
            // 
            this.Lbl_Adicionar.Location = new System.Drawing.Point(446, 315);
            this.Lbl_Adicionar.Name = "Lbl_Adicionar";
            this.Lbl_Adicionar.Size = new System.Drawing.Size(59, 25);
            this.Lbl_Adicionar.TabIndex = 2;
            this.Lbl_Adicionar.Text = "Adicionar";
            this.Lbl_Adicionar.UseVisualStyleBackColor = true;
            this.Lbl_Adicionar.Click += new System.EventHandler(this.Lbl_Adicionar_Click);
            // 
            // Llb_Editar
            // 
            this.Llb_Editar.Location = new System.Drawing.Point(511, 314);
            this.Llb_Editar.Name = "Llb_Editar";
            this.Llb_Editar.Size = new System.Drawing.Size(61, 25);
            this.Llb_Editar.TabIndex = 3;
            this.Llb_Editar.Text = "Editar";
            this.Llb_Editar.UseVisualStyleBackColor = true;
            this.Llb_Editar.Click += new System.EventHandler(this.Llb_Editar_Click);
            // 
            // Lbl_Remover
            // 
            this.Lbl_Remover.Location = new System.Drawing.Point(578, 314);
            this.Lbl_Remover.Name = "Lbl_Remover";
            this.Lbl_Remover.Size = new System.Drawing.Size(56, 25);
            this.Lbl_Remover.TabIndex = 4;
            this.Lbl_Remover.Text = "Remover";
            this.Lbl_Remover.UseVisualStyleBackColor = true;
            // 
            // listaClienteGrid
            // 
            this.listaClienteGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaClienteGrid.Location = new System.Drawing.Point(12, 12);
            this.listaClienteGrid.Name = "listaClienteGrid";
            this.listaClienteGrid.Size = new System.Drawing.Size(635, 296);
            this.listaClienteGrid.TabIndex = 5;
            this.listaClienteGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaClienteGrid_CellContentClick);
            // 
            // ConsultaDePessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 352);
            this.Controls.Add(this.listaClienteGrid);
            this.Controls.Add(this.Lbl_Remover);
            this.Controls.Add(this.Llb_Editar);
            this.Controls.Add(this.Lbl_Adicionar);
            this.Controls.Add(this.Lbl_Cancelar);
            this.Controls.Add(this.Lbl_Ok);
            this.Name = "ConsultaDePessoa";
            this.Text = "Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.listaClienteGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Lbl_Ok;
        private System.Windows.Forms.Button Lbl_Cancelar;
        private System.Windows.Forms.Button Lbl_Adicionar;
        private System.Windows.Forms.Button Llb_Editar;
        private System.Windows.Forms.Button Lbl_Remover;
        private System.Windows.Forms.DataGridView listaClienteGrid;
    }
}

