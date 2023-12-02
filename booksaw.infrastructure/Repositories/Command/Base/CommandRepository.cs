using booksaw_api.domain.Interfaces.Command.Base;
using booksaw_api.infrastructure.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw_api.infrastructure.Repositories.Command.Base
{
    public abstract class CommandRepository<T> : DbConnector, ICommandRepository<T> where T : class
    {
        public CommandRepository(IConfiguration configuration) : base(configuration) { }
        public abstract Task<T> AddAsync(T entity);
        public abstract Task UpdateAsync(T entity);
        public abstract Task DeleteAsync(int id);
    }
}
