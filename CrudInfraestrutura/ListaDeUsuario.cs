using Crud.Dominio;

namespace Crud.Infra
{
    public class ListaDeUsuario
    {
        private static List<Usuario>? instancia;

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
        public static int ObterProximoId()
        {
            var proximoId = (int)decimal.Zero;

            if (ListaDeUsuario.Instancia().Any())
            {
                proximoId = ListaDeUsuario.Instancia().Max(x => x.Id);
            }

            proximoId++;
            return proximoId;
        }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

    }
}
