namespace E_commerce_application.DTOs.Cart.Response
{
    public class CartItemsDTOs
    {
        public int Id { get; set; }
        public string NameOfProduct { get; set; }
        public int CartId { get; set; }

        public float Price { get; set; }
        public int Quantity { get; set; }

    }
}
