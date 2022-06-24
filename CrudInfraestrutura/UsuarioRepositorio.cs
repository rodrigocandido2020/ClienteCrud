using Crud.Dominio;

namespace Crud.Infra
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        public void AdicionarUsuario(Usuario usuario)
        {
            var listaDeUsuario = ListaDeUsuario.Instancia();
            var proximoId = ListaDeUsuario.ObterProximoId();
            usuario.Id = proximoId;
            listaDeUsuario.Add(usuario);
        }

        public List<Usuario> ObterTodos()
        {
            return ListaDeUsuario.Instancia();
        }

        public void RemoverUsuario(int id)
        {
            var listaDeUsuario = ListaDeUsuario.Instancia();
            var usuarioEncontrado = listaDeUsuario.Find(u => u.Id == id);
            listaDeUsuario.Remove(usuarioEncontrado ?? throw new Exception ("Não a Usuario para remover"));
        }

        public Usuario ObterPorId(int id)
        {
            var listaDeUsuario = ListaDeUsuario.Instancia();
            var usuario = listaDeUsuario.Find(u => u.Id == id);
            return usuario ?? throw new Exception("Id não pode ser nulo");
        }

        public void AtualizarUsuario(Usuario usuarioEditado)
        {
            var listaDeUsuarios = ListaDeUsuario.Instancia();
            var indice = listaDeUsuarios.FindIndex(usuario => usuario.Id == usuarioEditado.Id);
            listaDeUsuarios[indice] = usuarioEditado;
        }
    }
}