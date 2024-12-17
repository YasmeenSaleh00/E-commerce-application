namespace E_commerce_application.DTOs.Category.Response
{
    public class AllCategoryDTOs
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
