using System.ComponentModel.DataAnnotations.Schema;

namespace BootCart.Model
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Type { get; set; }
        public string ProductImage { get; set; }

        public int ParentId { get; set; }
        public ProductMaster Master { get; set; }
        [ForeignKey(nameof(Master))]
        public int SellerId { get; set; }

        public IEnumerable<Order> ProductOrder { get; set; }


    }
}
