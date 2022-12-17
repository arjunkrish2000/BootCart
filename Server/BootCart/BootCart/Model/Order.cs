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

        public double TotalAmount { get; set; }

        public DateTime OrderdDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public String Status { get; set; }


        public string Orderid { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
