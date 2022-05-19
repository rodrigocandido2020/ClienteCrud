using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteCrud
{
    public partial class CadastroDePessoa : Form
    {
        public Usuario Usuario { get; set; }

        public CadastroDePessoa(Usuario linha)
        {
            InitializeComponent();
            dateTimePicker1.Enabled = false;

            if(linha == null)
            {
                Usuario = new Usuario();
            }
            else
            {
                Usuario = linha;
            }
        }

        private void Lbl_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Lbl_Salvar_Click(object sender, EventArgs e)
        {
            Usuario.Id = idTxt.Text;
            Usuario.Nome = nomeTxt.Text;
            Usuario.Senha = senhaTxt.Text;
            Usuario.Email = emailTxt.Text;
            Usuario.DataCriacao = dateTimePicker1.Text;
            Usuario.DataNascimento = maskedTextData.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
