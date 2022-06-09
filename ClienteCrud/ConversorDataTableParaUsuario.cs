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

            var propriedadesDeUsuario = typeof(T).GetProperties().ToList();
            return tabelaDeDados
                .AsEnumerable()
                .Select(row => {
                  
                    var objetoUsuario = Activator.CreateInstance<T>();

                    propriedadesDeUsuario
                        .Where(propriedade => colunasNomes.Contains(propriedade.Name.ToLower()))
                        .ToList()
                        .ForEach(propriedade =>
                        {
                
                            if (colunasNomes.Contains(propriedade.Name.ToLower()))
                            {
                                var valor = row[propriedade.Name];
                                if (System.Convert.IsDBNull(valor))
                                {
                                    propriedade.SetValue(objetoUsuario, null);
                                }
                                else
                                {
                                    propriedade.SetValue(objetoUsuario, row[propriedade.Name]);
                                }
                            }
                        });
                       

                    return objetoUsuario;
                })
                .ToList();
        }
    }
}
