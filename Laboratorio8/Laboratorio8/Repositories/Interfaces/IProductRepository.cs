namespace Laboratorio8.Repositories.Interfaces;

using Models;

public interface IProductRepository : IRepository<product>
{
    public decimal getAveragePrice();
}
