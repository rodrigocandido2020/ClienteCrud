using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClienteCrud
{
    public partial class CadastroDeUsuario : Form
    {
        public Usuario Usuario { get; set; }

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
            idTxt.Text = linha.Id.ToString();
            nomeTxt.Text = linha.Nome;
            senhaTxt.Text = linha.Senha;
            emailTxt.Text = linha.Email;
            dateTimePicker1.Text = linha.DataCriacao.ToString();
            maskedTextData.Text = linha.DataNascimento.ToString();

        }

        private void Lbl_Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Tem certeza que fechar o cadastro de Usuario?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Lbl_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario.Nome = nomeTxt.Text;
                if (nomeTxt.Text == "")
                {
                    MessageBox.Show("Campo Nome Obrigátorio");
                    return;
                }
                Usuario.Senha = senhaTxt.Text;
                if (Usuario.Senha == "")
                {
                    MessageBox.Show("Campo senha Obrigátorio");
                    return;
                }                                                                                    
                if (true)
                {
                    Usuario.Email = emailTxt.Text;
                    Usuario.Email = emailTxt.Text;
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(Usuario.Email);
                    if (match.Success)
                    {
                        DialogResult = DialogResult.OK;
                    }

                    else
                    {
                        MessageBox.Show("Campo e-mail invalido");
                        return;
                    }
                }
                try
                {
                    if (maskedTextData.Text == "  /  /")
                    {
                        Usuario.DataNascimento = null;
                    }
                    else
                    {
                        Usuario.DataNascimento = DateTime.Parse(maskedTextData.Text);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Informa uma Data valida");
                    return;
                }
                Usuario.DataCriacao = DateTime.Parse(dateTimePicker1.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}