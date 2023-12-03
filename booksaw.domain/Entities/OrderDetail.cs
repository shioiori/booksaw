using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.domain.Entities
{
    [Table("order_details")]
    public class OrderDetail 
    {
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("book_id")]
        public int BookId { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("unit_price")]
        public decimal UnitPrice { get; set; }
        [Column("total_price")]
        public decimal TotalPrice
        {
            get { return UnitPrice * Quantity; }
            set { UnitPrice = value; }
        }
        public virtual Order Order { get; set; }
        public virtual Book Book { get; set; }
    }
}
