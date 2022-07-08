using FluentValidation;
using System.Text.RegularExpressions;

namespace Crud.Dominio
{
    public class ValidacaoDeUsuario : AbstractValidator<Usuario>
    {
        public ValidacaoDeUsuario()
        {
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
                .Must((usuario , email) => ValidarEmail(email))
                .WithMessage("O campo {PropertyName} é invalido");
        }

        private bool ValidarEmail(string email)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(email);
            return match.Success;
        }
    }
}
