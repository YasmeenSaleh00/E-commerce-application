namespace E_commerce_application.DTOs.Order.Response
{
    public class OrderDTOs
    {
        public int Id { get; set; }
        public string RequsterName { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Note { get; set; }

        public int CartId { get; set; }
        public int PaymentMethodId { get; set; }
        public int OrderStatus { get; set; }
    }
}
