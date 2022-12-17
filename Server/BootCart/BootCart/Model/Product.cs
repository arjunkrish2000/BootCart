using System.ComponentModel.DataAnnotations.Schema;

namespace BootCart.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductType { get; set; }

        [StringLength(50)]        
        public string ProductCategory { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string ProductImage { get; set; }

        public DateTime AddedDate { get; set; }
        public ProductMaster Master { get; set; }
        [ForeignKey(nameof(Master))]
        public int ProductMasterId { get; set; }

        public IEnumerable<Order> ProductOrder { get; set; }

        public IEnumerable<Cart> Addtocart { get; set; }

    }
}
