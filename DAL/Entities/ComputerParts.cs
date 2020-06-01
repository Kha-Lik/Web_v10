namespace DAL.Entities
{
    public class ComputerParts : BaseEntity
    {
        public Part Part { get; set; }
        public int PartId { get; set; }
        public Computer Computer { get; set; }
        public int ComputerId { get; set; }
    }
}