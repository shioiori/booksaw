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
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        public AuthorRepository(DbConnector dbConnector) : base(dbConnector) { }

        public async Task<Author> AddAsync(Author entity)
        {
            try
            {
                var query = @"INSERT INTO authors (name) 
                            VALUES (@Name);
                            SELECT LAST_INSERT_ID()";
                var id = await _connection.QueryFirstAsync<int>(query, entity, _transaction);
                entity.Id = id;
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Author>> GetAllAsync()
        {
            try
            {
                var query = @"SELECT * FROM authors";
                return (await _connection.QueryAsync<Author>(query)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<Author> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Author entity)
        {
            throw new NotImplementedException();
        }
    }
}
