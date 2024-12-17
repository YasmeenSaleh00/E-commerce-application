namespace E_commerce_application.Entities
{
    public class TransactionOrder:MainEntity
    {
        public int OrderId { get; set; }
        public string DeliveryInfo { get; set; }
        public DateOnly DeliveryDate { get; set; }
    }
}
