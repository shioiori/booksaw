using booksaw.domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.domain.Entities
{
    [Table("accounts")]
    public class Account 
    { 
        [Column("id")]
        public int Id { get; set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("account_type")]
        public string AccountType { get; set; }
        [Column("display_name")]
        public string DisplayName { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("avatar")]
        public string Avatar { get; set; } 
        public virtual BookClone BookClone { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
