namespace E_commerce_application.DTOs.Brand.Request
{
    public class UpdateBrandDTOs
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
