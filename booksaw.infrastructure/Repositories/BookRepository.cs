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
        public BookRepository(DbConnector dbConnector) : base(dbConnector) {
        }
        public async Task<IReadOnlyList<Book>> GetAllAsync()
        {
            try
            {
                var query = @"SELECT * FROM books b
                            INNER JOIN authors a ON b.author_id = a.id
                            INNER JOIN publishers p ON b.publisher_id = p.id
                            INNER JOIN categories c on b.category_id = c.id";
                var books = await _connection.QueryAsync<Book, Author, Publisher, Category, Book>(query, (book, author, publisher, category) =>
                {
                    book.Author = author;
                    book.Publisher = publisher;
                    book.Category = category;
                    return book;
                },
                splitOn: "id",
                transaction: _transaction);
                return books.ToList();
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
                var query = @"SELECT * FROM books b
                            INNER JOIN authors a ON b.author_id = a.id
                            INNER JOIN publishers p ON b.publisher_id = p.id
                            INNER JOIN categories c on b.category_id = c.id 
                            WHERE b.id = @id";
                var book = await _connection.QueryAsync<Book, Author, Publisher, Category, Book>(query, (book, author, publisher, category) =>
                {
                    book.Author = author;
                    book.Publisher = publisher;
                    book.Category = category;
                    return book;
                },
                splitOn: "id",
                param: new { id });
                return book.First();
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
                            INNER JOIN authors a ON b.author_id = a.id
                            INNER JOIN publishers p ON b.publisher_id = p.id
                            INNER JOIN categories c on b.category_id = c.id 
                            WHERE c.id = @id";
                var books = await _connection.QueryAsync<Book, Author, Publisher, Category, Book>(query, (book, author, publisher, category) =>
                {
                    book.Author = author;
                    book.Publisher = publisher;
                    book.Category = category;
                    return book;
                },
                splitOn: "id",
                param: new { id });
                return books.ToList();
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
                var query = @"SELECT * FROM books b
                            INNER JOIN authors a ON b.author_id = a.id
                            INNER JOIN publishers p ON b.publisher_id = p.id
                            INNER JOIN categories c on b.category_id = c.id 
                            WHERE a.id = @id";
                var books = await _connection.QueryAsync<Book, Author, Publisher, Category, Book>(query, (book, author, publisher, category) =>
                {
                    book.Author = author;
                    book.Publisher = publisher;
                    book.Category = category;
                    return book;
                },
                splitOn: "id",
                param: new { id });
                return books.ToList();
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
                var query = @"SELECT * FROM books b
                            INNER JOIN authors a ON b.author_id = a.id
                            INNER JOIN publishers p ON b.publisher_id = p.id
                            INNER JOIN categories c on b.category_id = c.id 
                            WHERE p.id = @id";
                var books = await _connection.QueryAsync<Book, Author, Publisher, Category, Book>(query, (book, author, publisher, category) =>
                {
                    book.Author = author;
                    book.Publisher = publisher;
                    book.Category = category;
                    return book;
                },
                splitOn: "id",
                param: new { id });
                return books.ToList();
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
                var query = @"INSERT INTO books (name, author_id, publisher_id, category_id, description, price, image_url, page) 
                            VALUES (@Name, @AuthorId, @PublisherId, @CategoryId, @Description, @Price, @ImageUrl, @Page);
                            SELECT LAST_INSERT_ID()";
                var id = await _connection.QueryFirstAsync<int>(query, entity, _transaction);
                return await GetByIdAsync(id);
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
                var query = @"UPDATE books SET name = @Name, author_id = @AuthorId, publisher_id = @PublisherId, category_id = @CategoryId
                            description = @Description, price = @Price,
                            image_url = @ImageUrl, page_number = @PageNumber 
                            WHERE id = @Id";
                await _connection.ExecuteAsync(query, entity, _transaction);
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
                await _connection.ExecuteAsync(query, new { id = id }, _transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
