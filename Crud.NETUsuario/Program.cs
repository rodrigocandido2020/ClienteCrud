using Crud.Dominio;
using Crud.Infra;
using Crud.Infra.Extensoes;
using FluentMigrator.Runner;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            using (var scope = builder.Services.CreateScope())
            {
                AtualizarBancoDeDados(scope.ServiceProvider);
            }

            MapeamentoDeTabela.Mapear();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConsultaDeUsuario(repositorioDoUsuario));
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) => ConfigurarServicos(services));
        }

        private static void AtualizarBancoDeDados(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }

        private static void ConfigurarServicos(IServiceCollection servicos)
        {
            servicos.AddScoped<IUsuarioRepositorio, UsuarioRepositorioComLinqDb>();
            servicos.AddScoped<IValidator<Usuario>, ValidacaoDeUsuario>();

            servicos.ConfigurarFluentMigration();
        }
    }
}
