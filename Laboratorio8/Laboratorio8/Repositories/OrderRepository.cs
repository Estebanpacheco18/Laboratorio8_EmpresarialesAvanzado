namespace Laboratorio8.Repositories;

using Data;
using Models;
using Interfaces;

public class OrderRepository : IOrderRepository
{
    private readonly LINQExampleContext _context;
    public OrderRepository(LINQExampleContext context) => _context = context;

    public IEnumerable<order> GetAll() => _context.orders.ToList();
    public order? GetById(int id) => _context.orders.Find(id);
    public void Add(order entity) { _context.orders.Add(entity); }
    public void Update(order entity) { _context.orders.Update(entity); }
    public void Delete(int id)
    {
        var entity = _context.orders.Find(id);
        if (entity != null) _context.orders.Remove(entity);
    }
}
