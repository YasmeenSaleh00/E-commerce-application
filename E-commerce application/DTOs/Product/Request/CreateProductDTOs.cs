namespace E_commerce_application.DTOs.Product.Request
{
    public class CreateProductDTOs
    {
        public string NameOfProudct { get; set; }
        public DateOnly ManufactureDate { get; set; }
        public string ImagePath { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        
    }
}
