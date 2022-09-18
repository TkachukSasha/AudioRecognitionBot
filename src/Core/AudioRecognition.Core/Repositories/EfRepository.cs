using AudioRecognition.Core.Abstractions;
using AudioRecognition.Core.Dal;

namespace AudioRecognition.Core.Repositories
{
    public class EfRepository<TEntity> : IEfRepository<TEntity>, IDisposable where TEntity : BaseEntity
    {
        private bool _disposed;
        private AudioRecognitionContext _context;

        public EfRepository(AudioRecognitionContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            _ = disposing;

            if (!_disposed && _context != null)
            {
                _context.Dispose();
                _context = null;

                _disposed = true;
            }
        }
    }
}
