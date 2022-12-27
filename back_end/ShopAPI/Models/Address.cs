using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    [Table("address")]
    public class Address
    {
        public int id { get; set; }
        public string city { get; set; } = null;
        public string district { get; set; } = null;
        public string address { get; set; } = null;
        public string name { get; set; } = null;
        public string phone { get; set; } = null;
        public string pin{ get; set; } = null;

        public string UserId { get; set; }
    }
}
