using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCrud
{
    public interface IUsuarioRepositorio
    {
        void AdicionarUsuario(Usuario Usuario);
        List<Usuario> ObterTodos();
        void RemoverUsuario(int id);
        int ObterPorId(int id);
        void EditarUsuario(Usuario usuario);

    }
}
