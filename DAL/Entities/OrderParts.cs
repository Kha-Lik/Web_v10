namespace DAL.Entities
{
    public class OrderParts : BaseEntity
    {
        public Part Part { get; set; }
        public int PartId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}