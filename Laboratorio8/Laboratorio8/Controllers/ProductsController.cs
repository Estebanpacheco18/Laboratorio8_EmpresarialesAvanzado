namespace Laboratorio8.Controllers;

using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using DTO;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET
    [HttpGet (template: "Productos")]
    public IActionResult GetAllProducts()
    {
        var products = _unitOfWork.Products
            .GetAll()
            .Select(p => new ProductDto
            {
                Id = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description
            })
            .ToList();

        return Ok(products);
    }
    
    [HttpGet("most-expensive")]
    public IActionResult GetMostExpensiveProduct()
    {
        var mostExpensive = _unitOfWork.Products
            .GetAll()
            .OrderByDescending(p => p.Price)
            .FirstOrDefault();
    
        if (mostExpensive == null)
            return NotFound();
    
        var dto = new ProductDto
        {
            Id = mostExpensive.ProductId,
            Name = mostExpensive.Name,
            Price = mostExpensive.Price,
            Description = mostExpensive.Description
        };
    
        return Ok(dto);
    }
    
    [HttpGet("average-price")]
    public IActionResult GetAverageProductPrice()
    {
        var averagePrice = _unitOfWork.Products.getAveragePrice();
    
        return Ok(averagePrice);
    }
    
    [HttpGet("without-description")]
    public IActionResult GetProductsWithoutDescription()
    {
        var products = _unitOfWork.Products
            .GetAll()
            .Where(p => string.IsNullOrEmpty(p.Description))
            .Select(p => new ProductDto
            {
                Id = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description
            })
            .ToList();
    
        return Ok(products);
    }
}
