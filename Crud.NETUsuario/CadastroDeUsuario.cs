using Crud.Dominio;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Crud.NetUsuario
{
    public partial class CadastroDeUsuario : Form
    {
        
        public Usuario Usuario { get; set; }
        public CadastroDeUsuario(Usuario usuario)
        {
           
            InitializeComponent();
            dateTimePicker1.Enabled = false;

            if (usuario == null)
            {
                Usuario = new Usuario();
            }
            else
            {
                Usuario = usuario;
                senhaTxt.Enabled = false;
                PreencherInputsDaTela(usuario);
            }
        }

        private void PreencherInputsDaTela(Usuario usuario)
        {
            idTxt.Text = usuario.Id.ToString();
            nomeTxt.Text = usuario.Nome;
            senhaTxt.Text = usuario.Senha;
            emailTxt.Text = usuario.Email;
            dateTimePicker1.Text = usuario.DataCriacao.ToString();
            maskedTextData.Text = usuario.DataNascimento.ToString();
        }

        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            try
            {
                if (DeveSairDoCadastroDeUsuario())
                {
                    DialogResult =  DialogResult.Cancel;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool DeveSairDoCadastroDeUsuario()
        {
            var resultadoPergunta = MessageBox
                .Show("Tem certeza que deseja fechar o cadastro de Usuario?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return resultadoPergunta == DialogResult.Yes;
        }
        private  void ValidarCampos()
        {
            if (nomeTxt.Text == string.Empty)
            {
                throw new Exception("Campo Nome Obrigátorio");
            }
            if (senhaTxt.Text == string.Empty)
            {
                throw new Exception("Campo senha Obrigátorio");
            }
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(emailTxt.Text);
            if (match.Success == false)
            {
                throw new Exception("Campo e-mail invalido");
            }
            const string dataVazia = "  /  /";
            var regexData = new Regex(@"(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/(19|20)\d{2}");
            var valorDaCaixa = regexData.Match(maskedTextData.Text);
            if (maskedTextData.Text != dataVazia && !valorDaCaixa.Success)
            {
                throw new Exception("Campo Data invalido");
            }

        }

        private void AoclicarEmSalvar(object sender, EventArgs e)
        {
            try
            {

                ValidarCampos();
                Usuario.Nome = nomeTxt.Text;
                Usuario.Senha = senhaTxt.Text;
                Usuario.Email = emailTxt.Text;
                Usuario.DataCriacao = DateTime.Parse(dateTimePicker1.Text);
                const string dataVazia = "  /  /";
                if (maskedTextData.Text == dataVazia)
                {
                    Usuario.DataNascimento = null;
                }
                else
                {
                    Usuario.DataNascimento = DateTime.Parse(maskedTextData.Text);
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}