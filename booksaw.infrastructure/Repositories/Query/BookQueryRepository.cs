using booksaw_api.domain.Entities;
using booksaw_api.domain.Interfaces;
using booksaw_api.domain.Interfaces.Query;
using booksaw_api.infrastructure.Repositories.Query.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw_api.infrastructure.Repositories
{
    public class BookQueryRepository : QueryRepository<Book>, IBookQueryRepository
    {
        public BookQueryRepository(IConfiguration configuration) : base(configuration) { }
        public async Task<IReadOnlyList<Book>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM books";

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Book>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM books b WHERE b.id = @id";
                using (var connection = CreateConnection())
                {
                    return await connection.QueryFirstOrDefaultAsync<Book>(query, new { id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IReadOnlyList<Book>> GetByCategory(int id)
        {
            try
            {
                var query = @"SELECT * FROM books b 
                            JOIN books_categories bc on b.id = bc.book_id
                            JOIN categories c on bc.category_id = c.id
                            WHERE c.id = @id";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Book>(query, new { id })).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IReadOnlyList<Book>> GetByAuthorAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM books b WHERE b.author_id = @id";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Book>(query, new { id })).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IReadOnlyList<Book>> GetByPublisherAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM books b WHERE b.publisher_id = @id";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Book>(query, new { id })).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
