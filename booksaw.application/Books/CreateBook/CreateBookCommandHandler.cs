using booksaw.application.Mapper;
using booksaw.application.Response;
using booksaw.domain.Entities;
using booksaw.domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Books.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookResponse>
    {
        private readonly IBookRepository _repository;
        public CreateBookCommandHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<BookResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var bookEntity = CustomMapper.Mapper.Map<Book>(request);
            var newBook = await _repository.AddAsync(bookEntity);
            var customerResponse = CustomMapper.Mapper.Map<BookResponse>(newBook);
            return customerResponse;
        }
    }
}
