using booksaw_api.domain.Entities;

namespace booksaw_api.domain.Interfaces.Query
{
    public interface IBookQueryRepository
    {
        Task<IReadOnlyList<Book>> GetAllAsync();
        Task<IReadOnlyList<Book>> GetByAuthorAsync(int id);
        Task<IReadOnlyList<Book>> GetByCategory(int id);
        Task<Book> GetByIdAsync(int id);
        Task<IReadOnlyList<Book>> GetByPublisherAsync(int id);
    }
}