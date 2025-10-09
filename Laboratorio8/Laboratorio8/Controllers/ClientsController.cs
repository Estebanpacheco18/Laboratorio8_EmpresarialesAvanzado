namespace Laboratorio8.Controllers;

using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using DTO;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    // GET
    [HttpGet(template: "clients")]
    public IActionResult GetAllClients()
    {
        var clients = _unitOfWork.Clients
            .GetAll()
            .Select(c => new ClientDto
            {
                Id = c.ClientId,
                Name = c.Name
            })
            .ToList();

        return Ok(clients);
    }
    
    [HttpGet("most-orders")]
    public IActionResult GetClientWithMostOrders()
    {
        var clientWithMostOrders = _unitOfWork.Orders
            .GetAll()
            .GroupBy(o => o.ClientId)
            .OrderByDescending(g => g.Count())
            .Select(g => new
            {
                ClientId = g.Key,
                OrderCount = g.Count()
            })
            .FirstOrDefault();
    
        if (clientWithMostOrders == null)
            return NotFound();
    
        var client = _unitOfWork.Clients.GetById(clientWithMostOrders.ClientId);
    
        if (client == null)
            return NotFound();
    
        return Ok(new
        {
            ClientId = client.ClientId,
            ClientName = client.Name,
            OrderCount = clientWithMostOrders.OrderCount
        });
    }
    
}
