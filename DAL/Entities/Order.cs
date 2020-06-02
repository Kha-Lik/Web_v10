using System;
using System.Collections;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Order : BaseEntity
    {
        public DateTime CreationDate { get; set; }
        public ICollection<OrderParts> PartsForReplacement { get; set; }
        public Owner Owner { get; set; }
        public int OwnerId { get; set; }
        public int RepairPrice { get; set; }
    }
}