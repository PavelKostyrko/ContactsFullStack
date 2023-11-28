using ContactsFS.Data.Contexts;

namespace ContactsFS.Logic.Services
{
    public class BaseService : IDisposable
    {
        protected readonly ContactDbContext _context;
        private bool disposed = false;
        public BaseService(ContactDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                _context?.Dispose();
            }

            disposed = true;    
        }

        ~BaseService()
        {
            Dispose(false);
        }
    }
}
