namespace BootCart.Model.RequestModels
{
    public class ProductViewModel
    {
        public string ProductType { get; set; }
        public string ProductCategory { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string ProductImage { get; set; }

        public string Color { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }

        public int ItemQty { get; set; }

    }
}
