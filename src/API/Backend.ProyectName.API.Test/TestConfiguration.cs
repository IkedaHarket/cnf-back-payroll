using Backend.ProyectName.API.Bootstrapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System.IO;

namespace Backend.ProyectName.API.Test
{
    public class TestConfiguration
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public TestConfiguration()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(
                     path: "appsettings.json",
                     optional: false,
                     reloadOnChange: true)
               .Build();

            IHostEnvironment env = new HostingEnvironment { EnvironmentName = Environments.Development };
            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddSingleton(env);

            serviceCollection.RegisterApplicationExtension();
            serviceCollection.RegisterInfraestructureExtension(configuration);

            // TODO Agregar Handlers correspondientes
            //serviceCollection.AddMediatR(typeof(SignMandateHandler));

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}