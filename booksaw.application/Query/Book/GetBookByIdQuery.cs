using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw_api.application.Query.Book
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public int Id { get; set; }
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}
