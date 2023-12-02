using booksaw.application.Mapper;
using booksaw.application.Response;
using booksaw.domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Books.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookResponse>
    {
        private readonly IBookRepository _repository;
        public GetBookByIdQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<BookResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var bookEntity = await _repository.GetByIdAsync(request.Id);
            return CustomMapper.Mapper.Map<BookResponse>(bookEntity);
        }
    }
}
