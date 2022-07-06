using Crud.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Api.CrudUsuario.Controllers
{
    [Route("Api/Controller")]
    [ApiController]
    public class UsuariosController : Controller
    {
        
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        [Route("ObterTodosOsUsuarios")]
        public IActionResult ObterTodosOsUsuarios()
        {
            try
            {
                var todosUsuarios = _usuarioRepositorio.ObterTodos();
                return Ok(todosUsuarios);
            }
            catch (Exception ex)
            {

                throw new Exception ("Não foi possivel encontrar Dados dos Usuario" , ex);
            }
            
        }

        [HttpGet]
        [Route("ObterPorId")]
        public IActionResult ObterPorIdUsuario(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new OkObjectResult(new { message = "Usuário não encontrado" });
                }
                var IdUsuario = _usuarioRepositorio.ObterPorId(id);
                return Ok(IdUsuario);

            }
            catch (Exception ex)
            {
                throw new Exception ("Não foi possivel encontrar Usuario Por Id" , ex);
            }
           
        }

        [HttpPost]
        [Route("AdicionarUsuario")]
        public IActionResult AdicionarUsuario(Usuario usuario)
        {
            try
            {
                _usuarioRepositorio.AdicionarUsuario(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar usuário" , ex);
            }
        }

        [HttpPut]
        [Route("AtualizarUsuario")]
        public IActionResult AtualizarUsuario(Usuario usuario)
        {
            try
            {
                var usuarioAtualizado = _usuarioRepositorio.ObterPorId(usuario.Id);
                usuarioAtualizado = usuario;
                _usuarioRepositorio.AtualizarUsuario(usuarioAtualizado);
                return new OkObjectResult(new { message = "Usuario Adicionado com Sucesso!!" });
            }
            catch (Exception ex)
            {
                throw new Exception("Erro No Id Do usuário" , ex);
            }
          
        }

        [HttpDelete]
        [Route("DeletarUsuario")]
        public IActionResult DeletarUsuario(int id)
        {
            try
            {
                var usuario = _usuarioRepositorio.ObterPorId(id);
                _usuarioRepositorio.RemoverUsuario(id);
                return new OkObjectResult(new { message = "Usuario excluido com sucesso" });
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Excluir Usuario" , ex);
            }
          
        }
    }
}
