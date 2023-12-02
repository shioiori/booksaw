using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace booksaw.application.Books.UpdateBook
{
    public class UpdateBookCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public string Description { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal SoldPrice { get; set; }
        public string ImageUrl { get; set; }
        public int Page { get; set; }
    }
}
