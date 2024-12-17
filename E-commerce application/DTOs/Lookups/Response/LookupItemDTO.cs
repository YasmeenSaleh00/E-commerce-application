namespace E_commerce_application.DTOs.Lookups.Response
{
    public class LookupItemDTO
    {
        public int Id { get; set; }
        public string LookupTypName { get; set; }
        public string Value { get; set; }
        public string CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
