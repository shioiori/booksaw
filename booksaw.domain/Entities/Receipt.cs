using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.domain.Entities
{
    [Table("receipts")]
    public class Receipt 
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("account_id")]
        public int AccountId { get; set; }
        [Column("total_price")]
        public int TotalPrice { get; set; }
        public virtual Account Account { get; set; }  
        public virtual ICollection<ReceiptDetail> ReceiptDetails { get; set; }
    }
}
