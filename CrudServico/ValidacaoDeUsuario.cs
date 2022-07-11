using FluentValidation;
using System.Text.RegularExpressions;

namespace Crud.Dominio
{
    public class ValidacaoDeUsuario : AbstractValidator<Usuario>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public ValidacaoDeUsuario(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            var usuario = new Usuario();
            RuleFor(u => u.Nome)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            RuleFor(u => u.Senha)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            RuleFor(u => u.Email)
                .Must((usuario, email) => ValidarEmail(email))
                .WithMessage("O campo {PropertyName} é invalido")
                .Must((usuario, email) => PodeCriarEmail(email, _usuarioRepositorio))
                .WithMessage("O campo {PropertyName} já existe no banco");
                
        }
        
        private bool ValidarEmail(string email)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(email);
            return match.Success;
        }

        private bool PodeCriarEmail(string email, IUsuarioRepositorio usuarioRepositorio)
        {
            var _usuarioRepositorio = usuarioRepositorio;
            bool resultado;
            resultado = _usuarioRepositorio.emailExisteNoBanco(email);

            if (resultado == true ? resultado = false : resultado = true) ;

            return resultado;
        }

        public void ValidacaoDeUsuarioAtualizado(Usuario usuario)
        {
            RuleFor(u => u.Nome)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            RuleFor(u => u.Senha)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            RuleFor(u => u.Email)
                .Must((usuario, email) => ValidarEmail(email))
                .WithMessage("O campo {PropertyName} é invalido");
        }

    }
}