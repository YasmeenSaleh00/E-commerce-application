namespace E_commerce_application.Entities
{
    public class ShoppingCart:MainEntity
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
 
        public int Quantity { get; set; }


    }
}
