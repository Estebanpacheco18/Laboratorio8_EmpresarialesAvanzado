namespace Laboratorio8.Repositories;

using Data;
using Models;
using Interfaces;

public class ProductRepository : IProductRepository
{
    private readonly LINQExampleContext _context;
    public ProductRepository(LINQExampleContext context) => _context = context;

    public IEnumerable<product> GetAll() => _context.products.ToList();
    public product? GetById(int id) => _context.products.Find(id);
    public void Add(product entity) { _context.products.Add(entity); }
    public void Update(product entity) { _context.products.Update(entity); }
    public void Delete(int id)
    {
        var entity = _context.products.Find(id);
        if (entity != null) _context.products.Remove(entity);
    }

    public decimal getAveragePrice()
    {
        var d = _context.products.Average(p => p.Price);
        return d;
    }
}
