using System.ComponentModel.DataAnnotations.Schema;

namespace BootCart.Model
{
    public class Review
    {
        public int Id { get; set; }
        public Product product { get; set; }
        [ForeignKey(nameof(product))]
        public int ProductId { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public int Ratings { get; set; }
        public String Reviews { get; set; }

    }
}
