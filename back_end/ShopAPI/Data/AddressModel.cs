namespace ShopAPI.Data
{
    public class AddressModel
    {
        public int AddressId { get; set; }
        public string? UserName { get; set; }
        public string? City { get; set; }
        public string? District { get; set; } 
        public string? AddressName { get; set; } 
        public string? Phone { get; set; }
        public string? Pin { get; set; }

        public int UserId { get; set; }
    }
}
