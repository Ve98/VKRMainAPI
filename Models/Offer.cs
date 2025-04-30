namespace MainAPI.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public double AdditionalExpenses { get; set; }
        public double Commission { get; set; }
        public double Amount { get; set; }
        public string? Description { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public Product? Product { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
