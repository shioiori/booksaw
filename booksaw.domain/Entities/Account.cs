using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw_api.domain.Entities
{
    public class Account : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccountType { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }

    }
}
