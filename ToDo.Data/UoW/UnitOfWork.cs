using ToDo.Data.Entities;
using ToDo.Data.Repository;

namespace ToDo.Data.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ToDoDbContext _context;

        public UnitOfWork(ToDoDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            ToDoRepository ??= new GenericRepository<Activity>(_context);
        }

        public IGenericRepository<Activity> ToDoRepository { get; set; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}