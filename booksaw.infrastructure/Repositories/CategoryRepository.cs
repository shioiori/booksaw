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
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(DbConnector dbConnector) : base(dbConnector) { }
        public async Task<Category> AddAsync(Category entity)
        {
            try
            {
                var query = @"INSERT INTO categories (name) 
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

        public Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Category>> GetAllAsync()
        {
            try
            {
                var query = @"SELECT * FROM categories";
                return (await _connection.QueryAsync<Category>(query)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
