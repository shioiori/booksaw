using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw_api.domain.Entities
{
    public class Receipt : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public int AccountId { get; set; }
        public int TotalPrice { get; set; }
    }
}
