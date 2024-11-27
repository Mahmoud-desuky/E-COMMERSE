using Back.Core.Entities;

namespace Back.Repository.Interface
{
    public interface IGenaricRepository<T> where T : class
    {

        Task<T> GetById(long id);
        Task<IReadOnlyList<T>> GetAll();

    }
}
