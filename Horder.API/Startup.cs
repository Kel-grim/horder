using Horder.Common.Interfaces.Repositories;
using Horder.Common.Interfaces.Services;
using Horder.Repository;
using Horder.Service;
using Microsoft.OpenApi.Models;

namespace Horder.API;

public class Startup
{
    #region Constructors

    public Startup(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    #endregion

    #region Private Properties

    private IConfiguration _configuration { get; }

    #endregion

    #region Public Methods

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Title = "Horder API",
                    Version = "v1",
                    Description = "Hording like a dragon"
                });
        });

        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IAccountRepository, AccountRepository>();

        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Horder API");
            c.RoutePrefix = string.Empty;
        });
        
        app.UseSwagger(options =>
        {
            options.SerializeAsV2 = true;
        });

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    #endregion
}