using booksaw.application.Mapper;
using booksaw.application.Response;
using booksaw.domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Books.GetBookByPublisher
{
    public class GetBookByPublisherQueryHandler : IRequestHandler<GetBookByPublisherQuery, List<BookResponse>>
    {
        private readonly IBookRepository _repository;
        public GetBookByPublisherQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BookResponse>> Handle(GetBookByPublisherQuery request, CancellationToken cancellationToken)
        {
            var bookEntities = await _repository.GetByPublisherAsync(request.PublisherId);
            return CustomMapper.Mapper.Map<List<BookResponse>>(bookEntities);
        }
    }
}
