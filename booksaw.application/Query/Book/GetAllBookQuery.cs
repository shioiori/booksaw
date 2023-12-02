using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw_api.application.Query.Book
{
    public record GetAllBookQuery : IRequest<List<Book>>
    {
    }
}
