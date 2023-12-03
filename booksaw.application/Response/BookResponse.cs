using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Response
{
    public class BookResponse
    {
        public string Name { get; set; }
        public AuthorResponse Author { get; set; }
        public PublisherResponse Publisher { get; set; }
        public CategoryResponse Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Page { get; set; }
    }
}
