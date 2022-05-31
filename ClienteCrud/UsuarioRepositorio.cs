using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCrud
{
    public class UsuarioRepositorio
    {

        public void Adicionar(Usuario usuario)
        {
            var listaDeUsuario = ListaDeUsuario.Instancia();
            listaDeUsuario.Add(usuario);
            if(listaDeUsuario.Count == 0)
            {
                usuario.Id = +1;
            }
        }

        public  List<Usuario> ObterTodos()
        {
            return ListaDeUsuario.Instancia();
        }

        public void Remover(Usuario usuario)
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
    }
}