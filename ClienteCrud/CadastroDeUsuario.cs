using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClienteCrud
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
        public string  UsuarioNulo()
        {
            const string DataVazia = "  /  /";

            if (maskedTextData.Text == DataVazia)
            {
                Usuario.DataNascimento = null;
            }
            return DataVazia;
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
            var regexData = new Regex(@"(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/(19|20)\d{2}");
            var x = regexData.Match(maskedTextData.Text);
            if (x.Success == true)
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
                Usuario.DataNascimento = DateTime.Parse(maskedTextData.Text);             
                Usuario.Email = emailTxt.Text;
                Usuario.DataCriacao = DateTime.Parse(dateTimePicker1.Text);
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