using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.domain.Entities
{
    [Table("receipt_details")]
    public class ReceiptDetail
    {
        [Column("receipt_id")]
        public int ReceiptId { get; set; }
        [Column("book_id")]
        public int BookId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("price")]
        public decimal UnitPrice { get; set; }
        [Column("total_price")]
        public decimal TotalPrice { 
            get {  return UnitPrice * Quantity; } 
            set {  UnitPrice = value; }
        }
        public virtual Receipt Receipt { get; set; }
        public virtual Book Book { get; set; }
    }
}
