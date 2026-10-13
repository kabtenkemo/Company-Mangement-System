using Company_Mangement_System.Data;
using Company_Mangement_System.Repo.Interface;

namespace Company_Mangement_System.Repo.Impelementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepo(AppDbContext context)
        {
            _context = context;
        }

        public Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            return Task.FromResult(entity);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null)
            {
                return Task.FromResult(false);
            }
            _context.Set<T>().Remove(entity);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = _context.Set<T>().ToList();
            return Task.FromResult(entities.AsEnumerable());
        }

        public Task<T> GetByIdAsync(int id)
        {
            var entity = _context.Set<T>().Find(id);
            return Task.FromResult(entity);
        }

        public Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return Task.FromResult(entity);
        }

    }
}
