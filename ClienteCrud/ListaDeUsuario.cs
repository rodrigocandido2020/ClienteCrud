using System.Collections.Generic;

namespace ClienteCrud
{
    public class ListaDeUsuario
    {
        private static List<Usuario> instancia;

        public static List<Usuario> Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new List<Usuario>();
                }
                return instancia;
            }
        }
    }
}
