namespace E_commerce_application.DTOs.Product.Response
{
    public class ProductViaBrandDTOs
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string NameOfProudct { get; set; }
        public DateOnly ManufactureDate { get; set; }
        public string ImagePath { get; set; }
        public int Quantity { get; set; }
        public int StatusProductId { get; set; }
    }
}
