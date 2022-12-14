namespace BootCart.Model
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Order OrderItems { get; set; }
        [ForeignKey(nameof(OrderItems))]
        public int OrderId { get; set; }
    }
}
