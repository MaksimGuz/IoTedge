using System;
using System.Collections.Generic;
using System.IO;
namespace StorageFacadeWebAPI
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Azure.Devices.Client;
    using StorageFacadeWebAPI.Services;
    using System.Threading.Tasks;

    public class Program
    {
        private static IServicesOnEdge storeToBlobService;
        private static IServicesOnEdge storeToMongoService;
        public static void Main(string[] args)
        {
            Init().Wait();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)                
                .UseStartup<Startup>();
        static async Task Init()
        {
            AmqpTransportSettings amqpSetting = new AmqpTransportSettings(TransportType.Amqp_Tcp_Only);
            ITransportSettings[] settings = { amqpSetting };

            // Open a connection to the Edge runtime
            ModuleClient ioTHubModuleClient = await ModuleClient.CreateFromEnvironmentAsync(settings);
            await ioTHubModuleClient.OpenAsync();
            Console.WriteLine("IoT Hub module client initialized.");
            
            storeToBlobService = new StoreToBlobService(ioTHubModuleClient);
            storeToMongoService = new StoreToMongoService(ioTHubModuleClient);

            await storeToBlobService.RegisterInputMessageHandlers();
            await storeToMongoService.RegisterInputMessageHandlers();
                        
            await storeToBlobService.RegisterMethodHandlers();
            await storeToMongoService.RegisterMethodHandlers();            
        }
    }
}