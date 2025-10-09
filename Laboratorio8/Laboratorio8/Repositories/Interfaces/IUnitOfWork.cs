namespace Laboratorio8.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IClientRepository Clients { get; }
    IProductRepository Products { get; }
    IOrderRepository Orders { get; }
    IOrderDetailRepository OrderDetails { get; }
    int Complete();
}
