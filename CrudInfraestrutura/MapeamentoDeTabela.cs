using Crud.Dominio;
using LinqToDB.Mapping;

namespace Crud.Infra
{
    public class MapeamentoDeTabela
    {
        private const string TabelaDeUsuario = "USUARIO";

        public static void Mapear()
        {
            var mapper = MappingSchema.Default.GetFluentMappingBuilder();

            mapper
                .Entity<Usuario>()
                .HasTableName(TabelaDeUsuario)
                .HasIdentity(x => x.Id)
                .HasPrimaryKey(x => x.Id);
                
        }
    }
}
