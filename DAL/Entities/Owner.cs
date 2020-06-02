using System.Collections.Generic;

namespace DAL.Entities
{
    public class Owner : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public ICollection<Computer> Computers { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}