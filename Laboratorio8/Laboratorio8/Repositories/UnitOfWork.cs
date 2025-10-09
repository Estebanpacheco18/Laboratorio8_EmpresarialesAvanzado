namespace Laboratorio8.Repositories;

using Data;
using Interfaces;

public class UnitOfWork : IUnitOfWork
{
    private readonly LINQExampleContext _context;
    public IClientRepository Clients { get; }
    public IProductRepository Products { get; }
    public IOrderRepository Orders { get; }
    public IOrderDetailRepository OrderDetails { get; }

    public UnitOfWork(LINQExampleContext context)
    {
        _context = context;
        Clients = new ClientRepository(_context);
        Products = new ProductRepository(_context);
        Orders = new OrderRepository(_context);
        OrderDetails = new OrderDetailRepository(_context);
    }

    public int Complete() => _context.SaveChanges();
    public void Dispose() => _context.Dispose();
}
