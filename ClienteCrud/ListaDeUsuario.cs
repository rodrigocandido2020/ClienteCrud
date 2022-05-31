using System.Collections.Generic;
using System.Linq;

namespace ClienteCrud
{
    public class ListaDeUsuario
    {
        public Usuario Usuario { get; set; }
        private static List<Usuario> instancia;

        public static List<Usuario> Instancia()
        {
            {
                if (instancia == null)
                {
                    instancia = new List<Usuario>();
                }
                return instancia;
            }
        }
        public static int AdicionarId()
        {
            var atual = (instancia ?? new List<Usuario>()).Max(x => x.Id);
           return atual++;
        }

    }
}
