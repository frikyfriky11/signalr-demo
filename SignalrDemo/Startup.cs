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
  }

  public void Configure(IApplicationBuilder app)
  {
    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllers();
      endpoints.MapHub<CustomersHub>("/signalr/customers-hub");
    });
  }
}
