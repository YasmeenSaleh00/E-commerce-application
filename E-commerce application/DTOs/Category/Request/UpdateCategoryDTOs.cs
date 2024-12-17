namespace E_commerce_application.DTOs.Category.Request
{
    public class UpdateCategoryDTOs
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
