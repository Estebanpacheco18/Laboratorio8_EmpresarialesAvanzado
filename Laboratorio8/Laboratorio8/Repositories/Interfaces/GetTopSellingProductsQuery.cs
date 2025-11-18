using Laboratorio8.DTO;
using Laboratorio8.Repositories.Interfaces;

namespace Laboratorio8.Queries;

public class GetTopSellingProductsQuery
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTopSellingProductsQuery(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public List<ProductDto> Execute()
    {
        return _unitOfWork.Products
            .GetAll()
            .Select(product => new ProductDto
            {
                Id = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            })
            .ToList();
    }
}