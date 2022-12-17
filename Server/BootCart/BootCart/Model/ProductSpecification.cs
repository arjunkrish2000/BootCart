using System.ComponentModel.DataAnnotations.Schema;

namespace BootCart.Model
{
    public class ProductSpecification
    {
        public int Id { get; set; }

        public string Color { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }

        public Product product { get; set; }
        [ForeignKey(nameof(product))]
        public int ProductId { get; set; }


    }
}
