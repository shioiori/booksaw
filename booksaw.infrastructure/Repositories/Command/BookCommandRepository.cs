using booksaw_api.domain.Entities;
using booksaw_api.domain.Interfaces.Command;
using booksaw_api.domain.Interfaces.Command.Base;
using booksaw_api.infrastructure.Repositories.Command.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw_api.infrastructure.Repositories.Command
{
    public class BookCommandRepository : CommandRepository<Book>, IBookCommandRepository
    {
        public BookCommandRepository(IConfiguration configuration) : base(configuration) { }
        public override async Task<Book> AddAsync(Book entity)
        {
            try
            {
                var query = @"INSERT INTO books (name, author_id, publisher_id, description, price, image_url, page_number) 
                            OUTPUT INSERTED.*
                            VALUES (@Name, @AuthorId, @Description, @Price, @ImageUrl, @PageNumber)";

                using (var connection = CreateConnection())
                {
                    return (await connection.QuerySingleAsync<Book>(query, entity));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public override async Task UpdateAsync(Book entity)
        {
            try
            {
                var query = @"UPDATE books SET name = @Name, author_id = @AuthorId, publisher_id = @PublisherId, 
                            description = @Description, price = @price, image_url = @ImageUrl, page_number = @PageNumber 
                            WHERE id = @Id";

                using (var connection = CreateConnection())
                {
                    await connection.ExecuteAsync(query, entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public override async Task DeleteAsync(int id)
        {
            try
            {
                var query = "DELETE FROM books WHERE id = @id";

                using (var connection = CreateConnection())
                {
                    await connection.ExecuteAsync(query, new { id = id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
