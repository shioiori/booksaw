using booksaw_api.application.Commands.Book;
using booksaw_api.application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw_api.application.Handle
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, BookResponse>
    {
        private readonly IBook
    }
}
