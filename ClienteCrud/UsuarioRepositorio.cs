using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCrud
{
    public class UsuarioRepositorio
    {

        public void AdicionarUsuario(Usuario usuario)
        {
            var listaDeUsuario = ListaDeUsuario.Instancia();
            var proximoId = ListaDeUsuario.AdicionarId();
            usuario.Id = proximoId;
            listaDeUsuario.Add(usuario);
        }

        public  List<Usuario> ObterTodos()
        {
            return ListaDeUsuario.Instancia();
        }


        public void RemoverUsuario(Usuario usuario)
        {
            var listaDeUsuario = ListaDeUsuario.Instancia();
            listaDeUsuario.Remove(usuario);
        }

        public Usuario ObterPorId(int id)
        {
            var usuarioDeRetorno = new Usuario();
            var listaDeUsuario = ListaDeUsuario.Instancia();
            listaDeUsuario.ForEach(usuario =>
            {
                if (usuario.Id == id)
                {
                    usuarioDeRetorno = usuario;
                }
            });
            return usuarioDeRetorno;
        }

        public void editarUsuario(Usuario usuarioEditado)
        {
            var listaDeUsuario = ListaDeUsuario.Instancia();
            listaDeUsuario.ForEach(usuario =>
            {
                if (usuario.Id == usuarioEditado.Id)
                {
                    usuario = usuarioEditado;
                }
            });
        }
    }
}