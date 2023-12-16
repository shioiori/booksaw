using booksaw.application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Publishers.GetAllPublisher
{
    public class GetAllPublisherQuery : IRequest<List<PublisherResponse>>
    {
    }
}
