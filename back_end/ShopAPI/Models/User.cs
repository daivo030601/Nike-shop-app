using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    [Table("user")]

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; }
        public string Name { get; set; } = null;
        public string PhoneNumber { get; set; } = null;

        public ICollection<Recipe> Recipes { get; set; } 

    }
}
