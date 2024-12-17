namespace E_commerce_application.Entities
{
    public class Order:MainEntity
    {
       
        public string RequsterName { get; set; }
        public string Phone { get; set; }
   
        public string Adress { get; set; }
        public string Note { get; set; }        
      
        public int StatusOrderId { get; set; }
        public int UserId { get; set; }
        public int CartId { get; set; }
        public int PaymentMethodId { get; set; }
        public float TotalAmount { get; set; }
    }
}
