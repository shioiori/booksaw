using booksaw.application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Books.GetBookByCategory
{
    public class GetBookByCategoryQuery : IRequest<List<BookResponse>>
    {
        public int CategoryId { get; set; }
    }
}
