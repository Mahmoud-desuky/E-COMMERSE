using System.Linq.Expressions;
using Back.Core.Entities;

namespace Back.Repository.Interface
{
    public interface IGenaricRepository<T> where T : BaseEntity
    {

        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAllAsync();
       IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string IncludeProperties = "");
       Task<T>GetEntityWithSpec(ISpacification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpacification<T> spec);
    }
}
