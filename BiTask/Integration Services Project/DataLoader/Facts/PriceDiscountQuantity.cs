using DataLoader.Dimentions;

namespace DataLoader.Facts
{
    public class PriceDiscountQuantity
    {
        //required by EF
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
    }
}
