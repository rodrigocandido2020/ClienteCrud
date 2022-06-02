using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCrud
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        public void AdicionarUsuario(Usuario usuario)
        {
            var listaDeUsuario = ListaDeUsuario.Instancia();
            var proximoId = ListaDeUsuario.AdicionarId();
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
            var idUsuario = listaDeUsuario.FindIndex(u => u.Id == id);
            var idAtual = id;
            var usuario = new Usuario();

            listaDeUsuario.Remove(usuario);
        }

        public int ObterPorId(int id)
        {
            var listaDeUsuario = ListaDeUsuario.Instancia();
            var idUsuario = listaDeUsuario.FindIndex(u => u.Id == id);
            var idAtual = id;
            return idAtual;
        }

        public void EditarUsuario(Usuario usuarioEditado)
        {
            var listaDeUsuario = ListaDeUsuario.Instancia();
            var IdUsuario = usuarioEditado.Id;
        }
    }
}