using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw_api.application.Responses
{
    public class BookResponse
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int PageNumber { get; set; }
    }
}
