namespace MainAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }
        public required string PartNumber { get; set; }
        public int Quantity { get; set; }
        public required string Measurement { get; set; }
        public required string Description { get; set; }
    }
}
