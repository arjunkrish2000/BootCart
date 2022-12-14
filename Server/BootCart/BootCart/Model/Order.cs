using System.ComponentModel.DataAnnotations.Schema;

namespace BootCart.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderPlacedDate { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public float Amount { get; set; }
        public Product Products { get; set; }
        [ForeignKey(nameof(Products))]
        public int ProductId { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public Address Addresss { get; set; }
        [ForeignKey(nameof(Addresss))]
        public int AddressId { get; set; }



    }
}
