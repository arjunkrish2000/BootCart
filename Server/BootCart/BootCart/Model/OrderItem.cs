namespace BootCart.Model
{
    public class OrderItem
    {

        public long Id { get; set; }

        public ApplicationUser User { get; set; }
        [ForeignKey(nameof(User))]
        public String UserId { get; set; }
        public Product Product { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public int IndividulaItemPrice { get; set; }

    }
}
