using booksaw.application.Mapper;
using booksaw.application.Response;
using booksaw.domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Books.GetBookByAuthor
{
    public class GetBookByAuthorQueryHandler : IRequestHandler<GetBookByAuthorQuery, List<BookResponse>>
    {
        private readonly IBookRepository _repository;
        public GetBookByAuthorQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BookResponse>> Handle(GetBookByAuthorQuery request, CancellationToken cancellationToken)
        {
            var bookEntities = await _repository.GetByAuthorAsync(request.AuthorId);
            return CustomMapper.Mapper.Map<List<BookResponse>>(bookEntities);
        }
    }
}
