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

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio , IValidator<Usuario> validador)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _Validador = validador;
        }

        [HttpGet]
        [Route("ObterTodosOsUsuarios")]
        public IActionResult ObterTodosOsUsuarios()
        {
                var todosUsuarios = _usuarioRepositorio.ObterTodos();
                return Ok(todosUsuarios);
            
        }

        [HttpGet]
        [Route("ObterPorId")]
        public IActionResult ObterPorIdUsuario(int id)
        {
                var IdUsuario = _usuarioRepositorio.ObterPorId(id);
                return Ok(IdUsuario);
           
        }

        [HttpPost]
        [Route("AdicionarUsuario")]
        public IActionResult AdicionarUsuario(Usuario usuario)
        {
            try
            {
                _Validador.ValidateAndThrow(usuario);
                _usuarioRepositorio.AdicionarUsuario(usuario);
                return new OkObjectResult(new { message = "Usuário adicionado" });
            }
            catch (Exception ex)
            {

                return BadRequest("Não foi possivel adicionar usuario" + ex.Message);
            }
        }

        [HttpPut]
        [Route("AtualizarUsuario")]
        public IActionResult AtualizarUsuario(Usuario usuario)
        {
                var usuarioAtualizado = _usuarioRepositorio.ObterPorId(usuario.Id);
                usuarioAtualizado = usuario;
                _usuarioRepositorio.AtualizarUsuario(usuarioAtualizado);
                return new OkObjectResult(new { message = "Usuario Atualizado com Sucesso!!" }); 
        }

        [HttpDelete]
        [Route("DeletarUsuario")]
        public IActionResult DeletarUsuario(int id)
        {
                _usuarioRepositorio.ObterPorId(id);
                _usuarioRepositorio.RemoverUsuario(id);
                return new OkObjectResult(new { message = "Usuario excluido com sucesso" });         
        }
    }
}
