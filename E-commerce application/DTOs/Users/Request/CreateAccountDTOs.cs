namespace E_commerce_application.DTOs.Users.Request
{
    public class CreateAccountDTOs
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int NationalityId { get; set; }
        public int GenderId { get; set; }
        public string Adress { get; set; }
    }
}
