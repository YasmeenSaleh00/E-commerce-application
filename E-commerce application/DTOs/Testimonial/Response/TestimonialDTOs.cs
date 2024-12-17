namespace E_commerce_application.DTOs.Testimonial.Response
{
    public class TestimonialDTOs
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public string Description { get; set; }
        public string? DescriptionAr { get; set; }
        public float Rating { get; set; }
        public int TestimonialTypeId { get; set; }
    }
}
