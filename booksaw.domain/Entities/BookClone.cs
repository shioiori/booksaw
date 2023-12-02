using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw_api.domain.Entities
{
    public class BookClone : BaseEntity
    {
        public int BookId { get; set; }
        public int CloneIndex { get; set; }
        public string ISBN { get; set; }
        public string IsSold { get; set; }
        public int CurrentPage { get; set; }
        public int UserId { get; set; }
    }
}
