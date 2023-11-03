using Amazon.Lambda.AspNetCoreServer;

namespace Horder.API;

public class LambdaEntryPoint : APIGatewayHttpApiV2ProxyFunction
{
    /// <summary>
    /// The Build has configure, logging, and amazon API Gateway already configured
    /// </summary>
    /// <param name="builder">An implementation of the <see cref="IWebHostBuilder"/> interface</param>
    protected override void Init(IWebHostBuilder builder)
    {
        builder.UseStartup<Startup>();
    }
}