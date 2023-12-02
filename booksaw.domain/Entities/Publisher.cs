﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.domain.Entities
{
    [Table("publishers")]
    public class Publisher 
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
