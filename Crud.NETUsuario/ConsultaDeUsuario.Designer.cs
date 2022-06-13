namespace ClienteCrud
{
    partial class ConsultaDeUsuario
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
            this.Lbl_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lbl_Ok.Location = new System.Drawing.Point(7, 365);
            this.Lbl_Ok.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Lbl_Ok.Name = "Lbl_Ok";
            this.Lbl_Ok.Size = new System.Drawing.Size(83, 29);
            this.Lbl_Ok.TabIndex = 0;
            this.Lbl_Ok.Text = "Ok";
            this.Lbl_Ok.UseVisualStyleBackColor = true;
            this.Lbl_Ok.Click += new System.EventHandler(this.AoClicarEmOk);
            // 
            // Lbl_Cancelar
            // 
            this.Lbl_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lbl_Cancelar.Location = new System.Drawing.Point(98, 365);
            this.Lbl_Cancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Lbl_Cancelar.Name = "Lbl_Cancelar";
            this.Lbl_Cancelar.Size = new System.Drawing.Size(76, 29);
            this.Lbl_Cancelar.TabIndex = 1;
            this.Lbl_Cancelar.Text = "Cancelar";
            this.Lbl_Cancelar.UseVisualStyleBackColor = true;
            this.Lbl_Cancelar.Click += new System.EventHandler(this.AoClicarEmCancelar);
            // 
            // Lbl_Adicionar
            // 
            this.Lbl_Adicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Adicionar.Location = new System.Drawing.Point(466, 365);
            this.Lbl_Adicionar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Lbl_Adicionar.Name = "Lbl_Adicionar";
            this.Lbl_Adicionar.Size = new System.Drawing.Size(69, 29);
            this.Lbl_Adicionar.TabIndex = 2;
            this.Lbl_Adicionar.Text = "Adicionar";
            this.Lbl_Adicionar.UseVisualStyleBackColor = true;
            this.Lbl_Adicionar.Click += new System.EventHandler(this.AoClicarEmAdicionar);
            // 
            // Llb_Editar
            // 
            this.Llb_Editar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Llb_Editar.Location = new System.Drawing.Point(543, 365);
            this.Llb_Editar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Llb_Editar.Name = "Llb_Editar";
            this.Llb_Editar.Size = new System.Drawing.Size(71, 29);
            this.Llb_Editar.TabIndex = 3;
            this.Llb_Editar.Text = "Editar";
            this.Llb_Editar.UseVisualStyleBackColor = true;
            this.Llb_Editar.Click += new System.EventHandler(this.AoClicarEmEditar);
            // 
            // Lbl_Remover
            // 
            this.Lbl_Remover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Remover.Location = new System.Drawing.Point(622, 365);
            this.Lbl_Remover.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Lbl_Remover.Name = "Lbl_Remover";
            this.Lbl_Remover.Size = new System.Drawing.Size(65, 29);
            this.Lbl_Remover.TabIndex = 4;
            this.Lbl_Remover.Text = "Remover";
            this.Lbl_Remover.UseVisualStyleBackColor = true;
            this.Lbl_Remover.Click += new System.EventHandler(this.AoClicarEmRemover);
            // 
            // listaClienteGrid
            // 
            this.listaClienteGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaClienteGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaClienteGrid.Location = new System.Drawing.Point(7, 12);
            this.listaClienteGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listaClienteGrid.Name = "listaClienteGrid";
            this.listaClienteGrid.Size = new System.Drawing.Size(680, 342);
            this.listaClienteGrid.TabIndex = 5;
            // 
            // ConsultaDeUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 406);
            this.Controls.Add(this.listaClienteGrid);
            this.Controls.Add(this.Lbl_Remover);
            this.Controls.Add(this.Llb_Editar);
            this.Controls.Add(this.Lbl_Adicionar);
            this.Controls.Add(this.Lbl_Cancelar);
            this.Controls.Add(this.Lbl_Ok);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ConsultaDeUsuario";
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

