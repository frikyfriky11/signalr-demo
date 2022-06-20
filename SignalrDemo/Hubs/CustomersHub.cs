using Microsoft.AspNetCore.SignalR;

namespace SignalrDemo.Hubs;

public class CustomersHub : Hub<ICustomersClientHub>
{
}