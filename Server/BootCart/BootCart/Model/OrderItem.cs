namespace BootCart.Model
{
    public class OrderItem
    {

        public long Id { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public Order Order { get; set; }
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
    }
}
