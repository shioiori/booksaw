using booksaw.application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Books.GetBookByPublisher
{
    public class GetBookByPublisherQuery : IRequest<List<BookResponse>>
    {
        public int PublisherId { get; set; }
    }
}
