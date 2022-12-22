namespace BootCart.Model
{
    public class OrderItem
    {

        public long Id { get; set; }

        public ApplicationUser User { get; set; }
        [ForeignKey(nameof(User))]
        public String UserId { get; set; }
        public ProductSpecification ProductSpecification { get; set; }
        [ForeignKey(nameof(ProductSpecification))]
        public int ProductSpecificationId { get; set; }
        public int Quantity { get; set; }

        public int IndividulaItemPrice { get; set; }

        public IEnumerable<ProductSpecification> Specifications { get; set; }

    }
}
