using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw_api.domain.Entities
{
    public class ReceiptDetail : BaseEntity
    {
        public int BookId { get; set; }
        public decimal Price { get; set; }
    }
}
