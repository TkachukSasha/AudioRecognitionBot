using AudioRecognition.Core.Abstractions;

namespace AudioRecognition.Core.Repositories
{
    public interface IEfRepository<TEntity> where TEntity : BaseEntity
    {
        Task AddAsync(TEntity entity);
    }
}
