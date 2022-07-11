using Crud.Dominio;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Crud.NetUsuario
{
    public partial class CadastroDeUsuario : Form
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public Usuario usuario { get; set; }
        public CadastroDeUsuario(int IdUsuario, IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            InitializeComponent();
            dateTimePicker1.Enabled = false;
            if (IdUsuario == 0)
            {
                usuario = new Usuario();
            }
            else
            {
                var usuarioSelecionado = _usuarioRepositorio.ObterPorId(IdUsuario);
                usuario = usuarioSelecionado;
                PreencherInputsDaTela(usuario);
                senhaTxt.Enabled = false;
            }
        }

        private void PreencherInputsDaTela(Usuario usuario)
        {
            idTxt.Text = usuario.Id.ToString();
            nomeTxt.Text = usuario.Nome;
            senhaTxt.Text = CriptografarSenha.DescriptografarSenha(usuario.Senha);
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
                throw new Exception("Erro inesperado" , ex);
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
            var TamanhoSenha = 50;
            if (senhaTxt.Text.Length > TamanhoSenha)
            {
                throw new Exception("senha não pode ser maior que 50 caracteres ");
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
                usuario.Nome = nomeTxt.Text;
                usuario.Senha = senhaTxt.Text;
                usuario.Email = emailTxt.Text;
                usuario.DataCriacao = DateTime.Parse(dateTimePicker1.Text);
                const string dataVazia = "  /  /";
                if (maskedTextData.Text == dataVazia)
                {
                    usuario.DataNascimento = null;
                }
                else
                {
                    usuario.DataNascimento = DateTime.Parse(maskedTextData.Text);
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