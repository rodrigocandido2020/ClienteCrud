using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCrud
{
    public class ConversorDataTableParaUsuario
    {
        public List<T> ConverterParaLista<T>(DataTable tabelaDeDados)
        {
            var colunasNomes = tabelaDeDados
                .Columns
                .Cast<DataColumn>()
                .Select(coluna => coluna.ColumnName.ToLower())
                .ToList();

            var propiedadesDeUsuario = typeof(T).GetProperties().ToList();

            return tabelaDeDados
                .AsEnumerable()
                .Select(row => {
                    var usuario = Activator.CreateInstance<T>();

                    propiedadesDeUsuario
                        .Where(propiedade => colunasNomes.Contains(propiedade.Name.ToLower()))
                        .ToList()
                        .ForEach(propiedade => propiedade.SetValue(usuario, row[propiedade.Name]));

                    return usuario;
                })
                .ToList();
        }
    }
}
