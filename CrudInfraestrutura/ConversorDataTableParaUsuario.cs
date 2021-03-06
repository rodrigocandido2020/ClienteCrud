using System.Data;

namespace Crud.Infra
{
    public static class ConversorDataTableParaUsuario
    {
        public static List<T> ConverterParaLista<T>(DataTable tabelaDeDados)
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
