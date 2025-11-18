using Laboratorio8.DTO;
using Laboratorio8.Repositories.Interfaces;

namespace Laboratorio8.Queries;

public class GetSalesByClientQuery
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSalesByClientQuery(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public List<SalesByClientDto> Execute()
    {
        return _unitOfWork.Clients
            .GetAll()
            .Select(client => new SalesByClientDto
            {
                ClientName = client.Name,
                TotalSales = 0 // No hay datos de ventas, así que dejamos esto en 0
            })
            .ToList();
    }
}