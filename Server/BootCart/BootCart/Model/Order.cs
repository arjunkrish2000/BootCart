using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace BootCart.Model
{
    public class Order
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey(nameof(User))]
        public string CustomerId { get; set; }

        public OrderItem OrderItems { get; set; }
        [ForeignKey(nameof(OrderItems))]
        public long OrderItemId { get; set; }
        public DateTime OrderedDate { get; set; } = DateTime.Now;

        public DateTime DeliveryDate { get; set; }

        [StringLength(100)]
        public String Address { get; set; }
      
        public Double TotalAmount { get; set; }

        public String Status { get; set; }

    }
}
