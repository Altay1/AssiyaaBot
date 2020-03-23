using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot;


namespace AssiyaaBot
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static async Task Main(string[] args)
        {
            //var configurationDirectoryParth = Path.Combine(Directory.GetCurrentDirectory(), "Configuration");
            //var configurationFile = $"{configurationDirectoryParth}\\appsettings.json";

            //var configuration = new ConfigurationBuilder()
            //    .AddJsonFile(configurationFile, false, false)
            //    .Build();

            var clientBotAccesToken = "972818445:AAEkLhZECKqOrZGh8sHBLMh5O9OL6C0c8yE";

            var serviceCollection = new ServiceCollection();

            //var connectionString = "(localdb)\\mssqllocaldb; Database = BotDb; Trusted_Connection = True;";

            //serviceCollection.AddDbContext<ApplicationDbContext>(options => 
            //options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AssiyaDb;Trusted_Connection=True;"), 
            //ServiceLifetime.Transient);

            serviceCollection.AddSingleton<ITelegramBotClient, TelegramBotClient>(service => 
            new TelegramBotClient(clientBotAccesToken));

            serviceCollection.AddTransient<MessageHandler>();

            _serviceProvider = serviceCollection.BuildServiceProvider();

            //var domaincontext = _serviceProvider.GetService<ApplicationDbContext>();
            //await domaincontext.Database.EnsureCreatedAsync();

            var botClient = _serviceProvider.GetService<ITelegramBotClient>();

            botClient.OnMessage += _serviceProvider.GetService<MessageHandler>().ProcessMessage;

            botClient.StartReceiving();

            Console.ReadLine();

        }
    }
}
