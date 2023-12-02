using booksaw.domain.Entities;
using booksaw.domain.Interfaces;
using booksaw.infrastructure.Data;
using booksaw.infrastructure.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.infrastructure.Repositories
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(DbConnector dbConnection) : base(dbConnection) {
        }
        public async Task<IReadOnlyList<Book>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM books";
                return (await _connection.QueryAsync<Book>(query)).ToList();
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
                return await _connection.QueryFirstOrDefaultAsync<Book>(query, new { id });
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
                return (await _connection.QueryAsync<Book>(query, new { id })).ToList();
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
                return (await _connection.QueryAsync<Book>(query, new { id })).ToList();
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
                return (await _connection.QueryAsync<Book>(query, new { id })).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Book> AddAsync(Book entity)
        {
            try
            {
                var query = @"INSERT INTO books (name, author_id, publisher_id, description, price, image_url, page_number) 
                            OUTPUT INSERTED.*
                            VALUES (@Name, @AuthorId, @Description, @Price, @ImageUrl, @PageNumber)";
                return (await _connection.QuerySingleAsync<Book>(query, entity));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task UpdateAsync(Book entity)
        {
            try
            {
                var query = @"UPDATE books SET name = @Name, author_id = @AuthorId, publisher_id = @PublisherId, 
                            description = @Description, price = @price, image_url = @ImageUrl, page_number = @PageNumber 
                            WHERE id = @Id";
                await _connection.ExecuteAsync(query, entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var query = "DELETE FROM books WHERE id = @id";
                await _connection.ExecuteAsync(query, new { id = id });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
