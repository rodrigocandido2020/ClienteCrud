using Crud.Dominio;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.CrudUsuario.Controllers
{
    [Route("Api/[controller]")]
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
                return StatusCode((int)HttpStatusCode.InternalServerError,ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObterPorIdUsuario([FromRoute] int id)
        {
            if (id == decimal.Zero)
            {
                return BadRequest("o Id deve ser Informado");
            }
            try
            {
                var IdUsuario = _usuarioRepositorio.ObterPorId(id);
                if (IdUsuario is null)
                {
                    return NotFound("Usuario não encontrado");
                }
                return Ok(IdUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AdicionarUsuario([FromBody] Usuario usuario)
        {
            if (usuario is null)
            {
                return BadRequest("O Usuario deve ser informado");
            }
            try
            {
                usuario.DataCriacao = DateTime.Now;
                _Validador.ValidateAndThrow(usuario);
                _usuarioRepositorio.AdicionarUsuario(usuario);

                return Created($"{usuario.Id}" , usuario);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizarUsuario([FromRoute]int id ,[FromBody] Usuario usuario)
        {
            if (usuario is null)
            {
                return BadRequest("O Usuario deve ser informado");
            }
            try
            {
                var usuarioDobanco = _usuarioRepositorio.ObterPorId(id);
                if (usuarioDobanco is null)
                {
                    return NotFound("Usuario não encontrado por Id");
                }
                usuario.DataCriacao = usuarioDobanco.DataCriacao;
                usuario.Id = id;
                _Validador.ValidateAndThrow(usuario);
                _usuarioRepositorio.AtualizarUsuario(usuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarUsuario([FromRoute] int id)
        {
            if (id == decimal.Zero)
            {
                return BadRequest("o Id deve ser informado");
            }
            try
            {
                var usuarioASerDeletado = _usuarioRepositorio.ObterPorId(id);
                if (usuarioASerDeletado is null)
                {
                    return NotFound($"Usuario não pode ser encontrado com o Id : {id}");
                }
                _usuarioRepositorio.RemoverUsuario(usuarioASerDeletado.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
