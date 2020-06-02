using System.Collections.Generic;

namespace DAL.Entities
{
    public class Computer : BaseEntity
    {
        public string Model { get; set; }
        public string Name { get; set; }
        public Owner Owner { get; set; }
        public int OwnerId { get; set; }
        public ICollection<ComputerParts> Parts { get; set; }
    }
}