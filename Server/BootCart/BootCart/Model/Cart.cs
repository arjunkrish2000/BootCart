namespace BootCart.Model
{
    public class Cart
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey(nameof(User))]
        public String UserId { get; set; }

        public float Price { get; set; }    
    }
}
