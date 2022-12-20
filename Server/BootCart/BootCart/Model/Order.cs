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

        public DateTime OrderedDate { get; set; } = DateTime.Now;

        public DateTime DeliveryDate { get; set; }

        public Address Address { get; set; }
        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }

        public double TotalAmount { get; set; }

    }
}
