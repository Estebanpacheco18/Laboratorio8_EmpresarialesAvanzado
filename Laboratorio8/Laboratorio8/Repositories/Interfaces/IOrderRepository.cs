namespace Laboratorio8.Repositories.Interfaces;

using Models;

public interface IOrderRepository : IRepository<order>
{
    IEnumerable<order> GetAllWithDetails();
}