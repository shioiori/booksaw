using booksaw.application.Mapper;
using booksaw.application.Response;
using booksaw.domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Books.GetAllBook
{
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, List<BookResponse>>
    {
        private readonly IBookRepository _repository;
        public GetAllBookQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BookResponse>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAllAsync();
            return CustomMapper.Mapper.Map<List<BookResponse>>(books);
        }
    }
}
