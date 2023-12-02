using booksaw_api.application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw_api.application.Commands.Book
{
    public class CreateBookCommand : IRequest<BookResponse>
    {

    }
}
