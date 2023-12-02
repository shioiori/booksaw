using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.domain.Entities
{
    [Table("book_clones")]
    public class BookClone
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("book_id")]
        public int BookId { get; set; }
        [Column("book_index")]
        public int BookIndex { get; set; }
        [Column("isbn")]
        public string ISBN { get; set; }
        [Column("is_sold")]
        public string IsSold { get; set; }
        [Column("current_page")]
        public int CurrentPage { get; set; }
        [Column("account_id")]
        public int AccountId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Account Account { get; set; }
    }
}
