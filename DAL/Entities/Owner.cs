using System.Collections.Generic;

namespace DAL.Entities
{
    public class Owner : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Computer> Computers { get; set; }
    }
}