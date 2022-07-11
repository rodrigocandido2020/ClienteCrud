using Crud.Dominio;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Api.CrudUsuario.Controllers
{
    [Route("Api/Controller")]
    [ApiController]
    public class UsuariosController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private IValidator<Usuario> _Validador;

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio, IValidator<Usuario> validador)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _Validador = validador;
        }

        [HttpGet]
        public IActionResult ObterTodosOsUsuarios()
        {
            try
            {
                var todosUsuarios = _usuarioRepositorio.ObterTodos();
                return Ok(todosUsuarios);
            }
            catch (Exception ex)
            {
                return NotFound("Não foi possivel obter todos usuarios " + ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObterPorIdUsuario([FromRoute] int id)
        {
            try
            {
                var IdUsuario = _usuarioRepositorio.ObterPorId(id);
                return Ok(IdUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi obter usuario por Id " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AdicionarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                usuario.DataCriacao = DateTime.Now;
                _Validador.ValidateAndThrow(usuario);
                _usuarioRepositorio.AdicionarUsuario(usuario);
                return Ok("Usuário adicionado");
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possivel adicionar usuario " + ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizarUsuario([FromRoute]int id ,[FromBody] Usuario usuario)
        {
            var _validador2 = new ValidacaoDeUsuario(_usuarioRepositorio);
            try
            {
                var usuarioAtualizado = usuario;
                try
                {
                    usuarioAtualizado = _usuarioRepositorio.ObterPorId(id);
                }
                catch (Exception ex)
                {
                    return BadRequest("Usuario não encontrado, verifique o id " + ex.Message);
                }
                usuarioAtualizado.Nome = usuario.Nome;
                usuarioAtualizado.Senha = usuario.Senha;
                usuarioAtualizado.DataNascimento = usuario.DataNascimento;
                
                if (usuarioAtualizado.Email != usuario.Email)
                {
                    _Validador.ValidateAndThrow(usuario);
                }
                else
                {
                    _validador2.ValidacaoDeUsuarioAtualizado(usuarioAtualizado);
                }
                usuarioAtualizado.Email = usuario.Email;
                _usuarioRepositorio.AtualizarUsuario(usuarioAtualizado);
                return Ok("Usuario Atualizado com Sucesso!!");
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possivel atualizar usuario " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarUsuario([FromRoute] int id)
        {
            try
            {
                _usuarioRepositorio.RemoverUsuario(id);
                return Ok("Usuario excluido com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possivel excluir usuario " + ex.Message);
            }
                         
        }
    }
}
