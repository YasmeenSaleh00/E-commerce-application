namespace E_commerce_application.Entities
{
    public class User:MainEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int NationalityId { get; set; }
        public int GenderId { get; set; }
        public string Adress { get; set; }
        public int UserTypeId { get; set; }
    }
}
