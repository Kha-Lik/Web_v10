using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Part : BaseEntity
    {
        public string Name { get; set; }
        public DateTime ManufactureDate { get; set; }
        public ICollection<ComputerParts> Computers { get; set; }
        public ICollection<OrderParts> Orders { get; set; }
    }
}