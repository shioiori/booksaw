using booksaw_api.application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw_api.application.Commands.Book
{
    public class DeleteBookCommand : IRequest<BookResponse>
    {
        public int Id { get; set; }
        public DeleteBookCommand(int id)
        {
            Id = id;
        }
    }
}
