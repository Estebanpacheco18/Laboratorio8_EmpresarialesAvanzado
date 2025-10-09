namespace Laboratorio8.Repositories;

using Data;
using Models;
using Interfaces;

public class OrderDetailRepository : IOrderDetailRepository
{
    private readonly LINQExampleContext _context;
    public OrderDetailRepository(LINQExampleContext context) => _context = context;

    public IEnumerable<orderdetail> GetAll() => _context.orderdetails.ToList();
    public orderdetail? GetById(int id) => _context.orderdetails.Find(id);
    public void Add(orderdetail entity) { _context.orderdetails.Add(entity); }
    public void Update(orderdetail entity) { _context.orderdetails.Update(entity); }
    public void Delete(int id)
    {
        var entity = _context.orderdetails.Find(id);
        if (entity != null) _context.orderdetails.Remove(entity);
    }
}
