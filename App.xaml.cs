using System.Configuration;
using System.Data;
using System.Windows;
using MessengerDesktop.Infrastructure.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MessengerDesktop.Core.Models;
using MessengerDesktop.Presentation.ViewModels;
using MessengerDesktop.Presentation.Views;
using MessengerDesktop.Core.Services;
using MessengerDesktop.Core.Services.Interfaces;

namespace MessengerDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();

            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();


            services.AddSingleton<DialogPanelViewModel>();
            services.AddSingleton<DialogPlaceholderViewModel>();
            services.AddSingleton<AuthPanelViewModel>();
            services.AddSingleton<MainPanelViewModel>();

            services.AddSingleton<IUserService, UserService>();

            services.AddSingleton<IChatUserRepository, ChatUserRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IRepository<MessageModel>, MessageRepository>();

            ServiceProvider = services.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }


    }

}
