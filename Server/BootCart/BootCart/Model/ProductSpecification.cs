using System.ComponentModel.DataAnnotations.Schema;

namespace BootCart.Model
{
    public class ProductSpecification
    {
        public int Id { get; set; }

        public string Attribute { get; set; }
        public Product product { get; set; }
        [ForeignKey(nameof(product))]
        public int ProductId { get; set; }


    }
}
