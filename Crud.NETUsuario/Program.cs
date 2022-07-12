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
            MapeamentoDeTabela.Mapear();

            var builder = CreateHostBuilder(args)
                .Build();

            builder.RunAsync();

            using (var scope = builder.Services.CreateScope())
            {
                AtualizarBancoDeDados(scope.ServiceProvider);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var Form = builder
              .Services
              .GetRequiredService<ConsultaDeUsuario>();

            Application.Run(Form);
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
            servicos.AddScoped<ConsultaDeUsuario>();
            servicos.AddScoped<IUsuarioRepositorio, UsuarioRepositorioComLinqDb>();
            servicos.AddScoped<IValidator<Usuario>, ValidacaoDeUsuario>();
            servicos.ConfigurarFluentMigration();
        }
    }
}
