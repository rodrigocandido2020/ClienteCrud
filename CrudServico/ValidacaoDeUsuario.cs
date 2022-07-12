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
            const string dataMinimaValida = "1753-01-01T12:06:13.975Z";

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
                .Must((usuario, email) => PodeCriarEmail(usuario, email))
                .WithMessage("O campo {PropertyName} já existe no banco");

            RuleFor(u => u.DataNascimento)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("O campo {PropertyName} é invalido")
                .GreaterThan(DateTime.Parse(dataMinimaValida))
                .WithMessage("O campo {PropertyName} é invalido");
        }
        
        private bool ValidarEmail(string email)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(email);
            return match.Success;
        }

        private bool PodeCriarEmail(Usuario usuario, string email)
        {
            bool resultado;
            if (usuario.Id == decimal.Zero)
            {
                resultado = _usuarioRepositorio.emailExisteNoBanco(email);
            }
            else
            {
                var usuarioASerAtualizado = _usuarioRepositorio.ObterPorId(usuario.Id);
                if(usuario.Email != usuarioASerAtualizado.Email)
                {
                    resultado = _usuarioRepositorio.emailExisteNoBanco(email);
                }
                else
                {
                    resultado = false;
                }
            }
            return !resultado;
        }
    }
}