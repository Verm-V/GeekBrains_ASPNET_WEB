using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacTest.Client;
using AutofacTest.FilesHandler;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutofacTest
{
	class Program
    {
		private static IContainer Container { get; set; }
		
		static async Task Main(string[] args)
        {
			// Экземпляры контейнеров
			var serviceCollection = new ServiceCollection();
			var builder = new ContainerBuilder();

			// Добавление HTTP клиента
			serviceCollection.AddHttpClient<MyClient>();

			// Транслируем содержимое ServiceCollection в Autofac
			builder.Populate(serviceCollection);

			// Конфигурируем сервисы
			ConfigureServices(builder);

			// Создаем контейнер
			var container = builder.Build();

			// Запускаем приложение 
			var myApp = container.Resolve<IMyApp>();
			await myApp.Run();

		}

		/// <summary>
		/// Конфигураыция серсисов
		/// </summary>
		/// <param name="builder"></param>
		private static void ConfigureServices(ContainerBuilder builder)
		{
			// Приложение
			builder.RegisterType<MyApp>().As<IMyApp>();
			// HTTP клиент
			builder.RegisterType<MyClient>().As<IMyClient>().SingleInstance();
			// Запись информации на диск
			builder.RegisterType<PostsWriter>().As<IPostsWriter>().SingleInstance();
		}
	}
}
