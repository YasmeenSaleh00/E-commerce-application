namespace E_commerce_application.DTOs.Order.Request
{
    public class CreateOrderDtOs
    {
        public string RequsterName { get; set; }
        public string Phone { get; set; }

        public string Adress { get; set; }
        public string Note { get; set; }

        public int CartId { get; set; }
        public int PaymentMethodId { get; set; }
    }
}
