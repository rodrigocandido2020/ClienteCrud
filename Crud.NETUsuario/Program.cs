using Crud.Dominio;
using Crud.Infra;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud.NetUsuario
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args)
                .Build();

            builder.RunAsync();

            var repositorioDoUsuario = builder
                .Services
                .GetRequiredService<IUsuarioRepositorio>();

            MapeamentoDeTabela.Mapear();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConsultaDeUsuario(repositorioDoUsuario));
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddScoped<IUsuarioRepositorio, UsuarioRepositorioComLinqDb>());
        }
    }
}
