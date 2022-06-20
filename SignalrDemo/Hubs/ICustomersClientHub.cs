namespace SignalrDemo.Hubs;

public interface ICustomersClientHub
{
  Task CustomerCreated(int id, string? name);
}
