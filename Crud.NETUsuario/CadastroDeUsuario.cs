using Crud.Dominio;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Crud.NetUsuario
{
    public partial class CadastroDeUsuario : Form
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private IValidator<Usuario> _Validador;
        public Usuario usuario { get; set; }
        public CadastroDeUsuario(int IdUsuario, IUsuarioRepositorio usuarioRepositorio, IValidator<Usuario> validador)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _Validador = validador;
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

        private void AoclicarEmSalvar(object sender, EventArgs e)
        {
            try
            {
                const string dataVazia = "  /  /";
                usuario.Nome = nomeTxt.Text;
                usuario.Senha = senhaTxt.Text;
                usuario.Email = emailTxt.Text;
                usuario.DataCriacao = DateTime.Parse(dateTimePicker1.Text);
                if (maskedTextData.Text == dataVazia)
                {
                    usuario.DataNascimento = null;
                }
                else
                {
                    usuario.DataNascimento = DateTime.Parse(maskedTextData.Text);
                }
                var usuarioDaTela = ObterUsuarioDaTela();
                _Validador.ValidateAndThrow(usuarioDaTela);
                usuario = usuarioDaTela;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
        private Usuario ObterUsuarioDaTela()
        {
            const string dataVazia = "  /  /";
            DateTime? data = null;
            if (maskedTextData.Text != dataVazia)
            {
                data = DateTime.Parse(maskedTextData.Text);
            }
            if (idTxt.Text == string.Empty)
            {
                return new Usuario
                {
                    //Id = int.Parse(idTxt.Text),
                    Nome = nomeTxt.Text,
                    Senha = senhaTxt.Text,
                    Email = emailTxt.Text,
                    DataCriacao = DateTime.Parse(dateTimePicker1.Text),
                    DataNascimento = data
                };
            }
            else
            {
                return new Usuario
                {
                    Id = int.Parse(idTxt.Text),
                    Nome = nomeTxt.Text,
                    Senha = senhaTxt.Text,
                    Email = emailTxt.Text,
                    DataCriacao = DateTime.Parse(dateTimePicker1.Text),
                    DataNascimento = data
                };
            }
        }
    }
}