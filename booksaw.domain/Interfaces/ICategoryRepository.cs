using booksaw.domain.Entities;
using booksaw.domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.domain.Interfaces
{
    public interface ICategoryRepository : ICommandRepository<Category>, IQueryRepository<Category>, IBaseRepository
    {
    }
}
