namespace Crud.Dominio
{
    public interface IUsuarioRepositorio
    {
        void AdicionarUsuario(Usuario Usuario);
        List<Usuario> ObterTodos();
        void RemoverUsuario(int id);
        Usuario ObterPorId(int id);
        void AtualizarUsuario(Usuario usuario);
        void ValidarEmail(string email);
    }
}
