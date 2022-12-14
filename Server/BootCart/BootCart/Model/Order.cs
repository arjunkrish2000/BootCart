using System.ComponentModel.DataAnnotations.Schema;

namespace BootCart.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderPlacedDate { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public float Amount { get; set; }
        public Product Product { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey(nameof(User))]
        public String UserId { get; set; }

        [StringLength(250)]
        public string? Address { get; set; }
    }
}
