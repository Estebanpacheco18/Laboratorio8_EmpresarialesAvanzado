namespace Laboratorio8.Repositories;

using Data;
using Models;
using Interfaces;

public class ClientRepository : IClientRepository
{
    private readonly LINQExampleContext _context;
    public ClientRepository(LINQExampleContext context) => _context = context;

    public IEnumerable<client> GetAll() => _context.clients.ToList();
    public client? GetById(int id) => _context.clients.Find(id);
    public void Add(client entity) { _context.clients.Add(entity); }
    public void Update(client entity) { _context.clients.Update(entity); }
    public void Delete(int id)
    {
        var entity = _context.clients.Find(id);
        if (entity != null) _context.clients.Remove(entity);
    }
}
