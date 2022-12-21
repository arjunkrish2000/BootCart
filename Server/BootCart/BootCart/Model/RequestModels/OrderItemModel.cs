namespace BootCart.Model.RequestModels
{
    public class OrderItemModel
    {
        public long Id { get; set; }

        //public int ProductId { get; set; }
       // public String UserId { get; set; }
        public int Quantity { get; set; }

        public int IndividulaItemPrice { get; set; }
    }
}
