using ASPNET_Lesson_01_DI.Client;
using ASPNET_Lesson_01_DI.FilesHandler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ASPNET_Lesson_01_DI
{
	class Program
	{
		static async Task Main(string[] args)
		{
			// Создаем сервисы и конфигурируем их
			var services = new ServiceCollection();
			ConfigureServices(services);

			// Запуск приложения
			using (ServiceProvider serviceProvider = services.BuildServiceProvider())
			{
				MyApp myApp = serviceProvider.GetService<MyApp>();
				await myApp.Run();
			}

		}

		/// <summary>
		/// Конфигурирует сервисы
		/// </summary>
		/// <param name="services">ServiceCollection</param>
		private static void ConfigureServices(ServiceCollection services)
		{
			services.AddTransient<MyApp>();

			// Клиенты для запросов к Агентам метрик
			services.AddHttpClient<IMyClient, MyClient>();

			// Работа с файлами
			services.AddSingleton<IPostsWriter, PostsWriter>();

			// Логгер
			services.AddLogging(builder =>
			{
				builder.SetMinimumLevel(LogLevel.Debug);
				builder.AddNLog("nlog.config");
			});
		}

	}
}
