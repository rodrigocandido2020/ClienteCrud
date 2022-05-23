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
    public partial class CadastroDeUsuario : Form
    {
        public Usuario Usuario { get; set; }
        public int Id { get; set; }

        public CadastroDeUsuario(Usuario linha)
        {
            ConsultaDePessoa consultaDePessoa = new ConsultaDePessoa();

            InitializeComponent();
            dateTimePicker1.Enabled = false;

            if (linha == null)
            {
                Usuario = new Usuario();
            }
            else
            {
                Usuario = linha;
                PreencherInputsDaTela(linha);
            }
        }

        private void PreencherInputsDaTela(Usuario linha)
        {
            nomeTxt.Text = linha.Nome;
            idTxt.Text = linha.Id.ToString();
            senhaTxt.Text = linha.Senha;
            emailTxt.Text = linha.Email;
            dateTimePicker1.Text = linha.DataCriacao;
            maskedTextData.Text = linha.DataNascimento;

        }

        private void Lbl_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Lbl_Salvar_Click(object sender, EventArgs e)
        {
            
            Usuario.Nome = nomeTxt.Text;
            Usuario.Senha = senhaTxt.Text;
            Usuario.Email = emailTxt.Text;
            Usuario.DataCriacao = dateTimePicker1.Text;
            Usuario.DataNascimento = maskedTextData.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void idTxt_TextChanged(object sender, EventArgs e)
        {
            //criar geração automatica de ID aqui

        }
    }
}