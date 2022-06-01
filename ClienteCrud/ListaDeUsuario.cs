using System.Collections.Generic;
using System.Linq;

namespace ClienteCrud
{
    public class ListaDeUsuario
    {
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
            var proximoId = 0;

            if (ListaDeUsuario.instancia.Count == 0)
            {
                proximoId = 0;

            }
            else
            {
                proximoId = ListaDeUsuario.instancia.Last().Id;
                
            }
            proximoId++;
            return proximoId;
        }

    }
}
