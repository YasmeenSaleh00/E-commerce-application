namespace E_commerce_application.Entities
{
    public class Testimonial:MainEntity
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public string? DescriptionAr { get; set; }
        public float Rating { get; set; }
        public int TestimonialTypeId { get; set; }
    }
}
