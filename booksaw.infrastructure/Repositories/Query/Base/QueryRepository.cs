using booksaw_api.infrastructure.Data;
using booksaw_api.domain.Interfaces.Query.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw_api.infrastructure.Repositories.Query.Base
{
    public class QueryRepository<T> : DbConnector, IQueryRepository<T> where T : class
    {
        public QueryRepository(IConfiguration configuration)
            : base(configuration)
        {

        }
    }
}
