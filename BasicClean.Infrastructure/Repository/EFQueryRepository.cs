namespace BasicClean.Infrastructure.Repository
{
    internal class EFQueryRepository<T, TKey> : IQueryRepository<T, TKey> where T : BaseEntity<TKey>
    {
        readonly TodoDbContext _context;
        public EFQueryRepository(TodoDbContext todoDbContext)
        {
            _context = todoDbContext;
        }
        public T Get(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().FirstOrDefault(match);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>()
               .Where(predicate).ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
               .Where(predicate).ToListAsync();
        }

        public  async Task<T> GetAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().Where(match).FirstOrDefaultAsync();
        }
    }
}
