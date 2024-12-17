namespace E_commerce_application.DTOs.Users.Response
{
    public class UsersDTOs
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int NationalityId { get; set; }
        public int GenderId { get; set; }
        public string Adress { get; set; }
        public int UserTypeId { get; set; }
        public bool isDeleted { get; set; }
    }
}
