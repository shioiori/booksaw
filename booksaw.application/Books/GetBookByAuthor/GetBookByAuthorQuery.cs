using booksaw.application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Books.GetBookByAuthor
{
    public class GetBookByAuthorQuery : IRequest<List<BookResponse>>
    {
        public int AuthorId {  get; set; }
    }
}
