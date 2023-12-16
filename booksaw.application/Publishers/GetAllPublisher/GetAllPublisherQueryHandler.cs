using booksaw.application.Mapper;
using booksaw.application.Response;
using booksaw.domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Publishers.GetAllPublisher
{
    public class GetAllPublisherQueryHandler : IRequestHandler<GetAllPublisherQuery, List<PublisherResponse>>
    {
        private readonly IPublisherRepository _publisherRepository;
        public GetAllPublisherQueryHandler(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }
        public async Task<List<PublisherResponse>> Handle(GetAllPublisherQuery request, CancellationToken cancellationToken)
        {
            var publishers = await _publisherRepository.GetAllAsync();
            return CustomMapper.Mapper.Map<List<PublisherResponse>>(publishers);
        }
    }
}
