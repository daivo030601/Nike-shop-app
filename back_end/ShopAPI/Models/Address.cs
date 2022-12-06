using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    [Table("address")]
    public class Address
    {
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string AddressName { get; set; }
        public string Phone { get; set; }
        public string Pin{ get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
