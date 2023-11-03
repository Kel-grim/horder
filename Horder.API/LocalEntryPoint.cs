namespace Horder.API;

public class LocalEntryPoint
{
    /// <summary>
    /// The method used to bootstrap the application
    /// </summary>
    /// <param name="args">An array of start-up arguments</param>
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    /// <summary>
    /// Method to provision the host host builder
    /// </summary>
    /// <param name="args">An array of start-up arguments</param>
    /// <returns>An implementation of the <see cref="IHostBuilder"/> interface</returns>
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                    .ConfigureAppConfiguration((context, builder) =>
                    {
                        builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    })
                    .UseStartup<Startup>();
            });
}