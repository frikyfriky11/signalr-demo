using SignalrDemo.Hubs;
using SignalrDemo.Services;

namespace SignalrDemo;

public class Startup
{
  public void ConfigureServices(IServiceCollection services)
  {
    services.AddControllers();

    services.AddSingleton<IRepository, InMemoryRepository>();

    services.AddSignalR();

    services.AddCors(options =>
    {
      options.AddDefaultPolicy(policy =>
      {
        policy
          .SetIsOriginAllowed(_ => true)
          .AllowCredentials()
          .AllowAnyHeader()
          .AllowAnyMethod();
      });
    });
  }

  public void Configure(IApplicationBuilder app)
  {
    app.UseCors();
    
    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllers();
      endpoints.MapHub<CustomersHub>("/signalr/customers-hub");
    });
  }
}
