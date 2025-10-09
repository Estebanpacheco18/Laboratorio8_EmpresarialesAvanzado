namespace Laboratorio8.Controllers;

using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using DTO;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public OrdersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET
    [HttpGet("products")]
    public IActionResult GetOrderProducts([FromQuery] int orderId)
    {
        var products = _unitOfWork.Products.GetAll().ToList();

        var productsInOrder = _unitOfWork.OrderDetails
            .GetAll()
            .Where(od => od.OrderId == orderId)
            .Select(od => new OrderProductDetailDto
            {
                ProductName = products.FirstOrDefault(p => p.ProductId == od.ProductId)?.Name ?? "",
                Quantity = od.Quantity
            })
            .ToList();

        return Ok(productsInOrder);
    }
    
    [HttpGet("total-products")]
    public IActionResult GetTotalProductsInOrder([FromQuery] int orderId)
    {
        var totalQuantity = _unitOfWork.OrderDetails
            .GetAll()
            .Where(od => od.OrderId == orderId)
            .Select(od => od.Quantity)
            .Sum();
    
        return Ok(totalQuantity);
    }
    
    [HttpGet("after-date")]
    public IActionResult GetOrdersAfterDate([FromQuery] DateTime date)
    {
        var orders = _unitOfWork.Orders
            .GetAll()
            .Where(o => o.OrderDate > date)
            .Select(o => new OrderDto
            {
                Id = o.OrderId,
                ClientId = o.ClientId,
                Date = o.OrderDate
            })
            .ToList();
    
        return Ok(orders);
    }
    
    [HttpGet("orders-details")]
    public IActionResult GetAllOrdersWithDetails()
    {
        var ordersWithDetails = _unitOfWork.OrderDetails
            .GetAll()
            .Select(od => new
            {
                OrderId = od.OrderId,
                ProductName = _unitOfWork.Products.GetAll()
                    .FirstOrDefault(p => p.ProductId == od.ProductId)?.Name ?? "Product not found",
                Quantity = od.Quantity
            })
            .ToList();
    
        return Ok(ordersWithDetails);
    }
    
    [HttpGet("products-by-client")]
    public IActionResult GetProductsByClient([FromQuery] int clientId)
    {
        var orders = _unitOfWork.Orders
            .GetAll()
            .Where(o => o.ClientId == clientId)
            .Select(o => o.OrderId)
            .ToList();
    
        var products = _unitOfWork.OrderDetails
            .GetAll()
            .Where(od => orders.Contains(od.OrderId))
            .Select(od => new
            {
                ProductName = _unitOfWork.Products.GetAll()
                    .FirstOrDefault(p => p.ProductId == od.ProductId)?.Name ?? "Product not found"
            })
            .Distinct()
            .ToList();
    
        return Ok(products);
    }
    
[HttpGet("clients-by-product")]
    public IActionResult GetClientsByProduct([FromQuery] int productId)
    {
        var orders = _unitOfWork.OrderDetails
            .GetAll()
            .Where(od => od.ProductId == productId)
            .Select(od => od.OrderId)
            .Distinct()
            .ToList();
    
        var clients = _unitOfWork.Orders
            .GetAll()
            .Where(o => orders.Contains(o.OrderId))
            .Select(o => new
            {
                ClientId = o.ClientId,
                ClientName = _unitOfWork.Clients.GetById(o.ClientId)?.Name ?? "Cliente no encontrado"
            })
            .Distinct()
            .ToList();
    
        return Ok(clients);
    }
    
}
