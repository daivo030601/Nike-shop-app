namespace ShopAPI.Data
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; } = null;
        public string? PhoneNumber { get; set; } = null;
    }
}
