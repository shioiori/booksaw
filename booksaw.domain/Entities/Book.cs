using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.domain.Entities
{
    [Table("books")]
    public class Book
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("author_id")]
        public int AuthorId { get; set; }
        [Column("publisher_id")]
        public int PublisherId { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("import_price")]
        public decimal ImportPrice { get; set; }
        [Column("sold_price")]
        public decimal SoldPrice { get; set; }
        [Column("image_url")]
        public string ImageUrl { get; set; }
        [Column("page")]
        public int Page { get; set; }
        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<BookClone> Clones { get; set; }
    }
}
