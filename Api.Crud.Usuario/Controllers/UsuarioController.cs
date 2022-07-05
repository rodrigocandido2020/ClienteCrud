using Crud.Dominio;
using Crud.Infra;
using Microsoft.AspNetCore.Mvc;

namespace Api.Crud.Usuario.Controllers
{
    public class UsuarioController : Controller
    {
        
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
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
            if(id == 0)
            {
                return new OkObjectResult(new { message = "Usuário não encontrado" });
            }
            var IdUsuario = _usuarioRepositorio.ObterPorId(id);
            return Ok(IdUsuario);
        }
    }
}
