using booksaw.application.Mapper;
using booksaw.application.Response;
using booksaw.domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Books.GetBookByCategory
{
    public class GetBookByCategoryQueryHandler : IRequestHandler<GetBookByCategoryQuery, List<BookResponse>>
    {
        private readonly IBookRepository _repository;
        public GetBookByCategoryQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BookResponse>> Handle(GetBookByCategoryQuery request, CancellationToken cancellationToken)
        {
            var bookEntities = await _repository.GetByAuthorAsync(request.CategoryId);
            return CustomMapper.Mapper.Map<List<BookResponse>>(bookEntities);
        }
    }
}
