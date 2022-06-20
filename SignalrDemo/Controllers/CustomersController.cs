using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalrDemo.Hubs;
using SignalrDemo.Models;
using SignalrDemo.Services;

namespace SignalrDemo.Controllers;

public class CustomersController : ControllerBase
{
  [HttpGet]
  [Route("customers")]
  public ActionResult<IEnumerable<Customer>> GetList([FromServices] IRepository repository)
  {
    return repository.GetList();
  }

  [HttpGet]
  [Route("customers/{id}")]
  public ActionResult<Customer> GetById([FromServices] IRepository repository, int id)
  {
    return repository.Get(id) ?? (ActionResult<Customer>)NotFound();
  }

  [HttpPost]
  [Route("customers")]
  public ActionResult Create([FromServices] IRepository repository, [FromServices] IHubContext<CustomersHub, ICustomersClientHub> customersHub, [FromBody] Customer customer)
  {
    repository.Add(customer);

    customersHub.Clients.All.CustomerCreated(customer.Id, customer.Name);
    
    return NoContent();
  }

  [HttpPut]
  [Route("customers/{id}")]
  public ActionResult Update([FromServices] IRepository repository, int id, [FromBody] Customer customer)
  {
    repository.Update(id, customer);

    return NoContent();
  }

  [HttpDelete]
  [Route("customers/{id}")]
  public ActionResult Delete([FromServices] IRepository repository, int id)
  {
    repository.Delete(id);

    return NoContent();
  }
}
