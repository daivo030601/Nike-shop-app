using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    [Table("address")]
    public class Address
    {
        public int AddressId { get; set; }
        public string UserName { get; set; } = null;
        public string City { get; set; } = null;
        public string District { get; set; } = null;
        public string AddressName { get; set; } = null;
        public string Phone { get; set; } = null;
        public string Pin{ get; set; } = null;

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
