using booksaw.domain.Entities;
using booksaw.domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.domain.Interfaces
{
    public interface IBookRepository : ICommandRepository<Book>, IQueryRepository<Book>, IBaseRepository
    {
        Task<IReadOnlyList<Book>> GetByAuthorAsync(int id);
        Task<IReadOnlyList<Book>> GetByCategory(int id);
        Task<IReadOnlyList<Book>> GetByPublisherAsync(int id);
    }
}
