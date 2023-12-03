using booksaw.domain.Interfaces.Base;
using booksaw.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.infrastructure.Repositories.Base
{
    public class BaseRepository : IBaseRepository
    {
        protected readonly IDbConnection _connection;
        protected IDbTransaction _transaction;
        public BaseRepository(DbConnector dbConnection)
        {
            _connection = dbConnection.CreateConnection();
        }

        public void BeginTransaction()
        {
            if (_connection.State != ConnectionState.Open) {
                _connection.Open();
            }
            _transaction = _connection.BeginTransaction();
        }

        public int Commit()
        {
            try
            {
                _transaction.Commit();
                return 1; 
            }
            catch
            {
                _transaction.Rollback();
                return 0; 
            }
            finally
            {
                _transaction?.Dispose();
            }
        }

        public void Dispose()
        {
            _transaction?.Commit();
            _connection?.Close();
        }
    }
}
