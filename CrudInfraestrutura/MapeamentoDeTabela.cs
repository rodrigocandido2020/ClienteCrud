using Crud.Dominio;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
