using di.repaso._2026.Backend.Modelo;
using di.repaso._2026.Backend.Repositorio;
using di.repaso._2026.Frontend.Dialogos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Data;
using System.Windows;

namespace di.repaso._2026
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;
        /// <summary>
        /// Constructor de la clase App
        /// </summary>
        public App()
        {
            // Configurar el contenedor de inyección de dependencias
            var serviceCollection = new ServiceCollection();
            // Configurar los servicios
            ConfigureServices(serviceCollection);
            // Construir el proveedor de servicios
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            // Configurar el contexto de la base de datos
            services.AddDbContext<NbaContext>();
            // Configurar el servicio de logging
            services.AddLogging(configure => configure.AddConsole());
            // Registrar repositorios genéricos
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            // Registrar servicios y vistas aquí
            // En primer lugar registramos la ventana principal*/
            services.AddSingleton<Login>();
            // A continuación, registramos los repositorios específicos
            // Lo hacemos con AddScoped para que se cree una nueva instancia
            // de cada repositorio por cada petición
            // Esto es útil para evitar problemas de concurrencia
            
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            // Se genera la ventana de Login
            var ventanaLogin = _serviceProvider.GetService<Login>();
            ventanaLogin.Show();
            base.OnStartup(e);
        }
    }

}
