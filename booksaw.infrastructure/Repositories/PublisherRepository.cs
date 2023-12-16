using booksaw.domain.Entities;
using booksaw.domain.Interfaces;
using booksaw.infrastructure.Data;
using booksaw.infrastructure.Repositories.Base;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.infrastructure.Repositories
{
    public class PublisherRepository : BaseRepository, IPublisherRepository
    {
        public PublisherRepository(DbConnector dbConnector) : base(dbConnector) { }
        public Task<Publisher> AddAsync(Publisher entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Publisher>> GetAllAsync()
        {
            try
            {
                var query = @"SELECT * FROM publishers";
                return (await _connection.QueryAsync<Publisher>(query)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<Publisher> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Publisher entity)
        {
            throw new NotImplementedException();
        }
    }
}
