using Back.Infrastracture.Data;
using Back.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Back.Repository.Logic
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : class
    {
        private readonly StoreContext _context;
        private DbSet<T> _dbSet;
        public GenaricRepository(StoreContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<IReadOnlyList<T>> GetAll()
        {
            try
            {
                return await _dbSet.ToListAsync();

            }catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<T> GetById(long Id)
        {
            try
            {
                var Find = _dbSet.FindAsync(Id);
                return await Find;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
