using System.ComponentModel.DataAnnotations;

namespace ApiSincinaty.Models
{
    public class Users
    {
        [Key]
        public int user_id { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string? password { get; set; }
        public string user_type { get; set; }
        public string status { get; set; }
        public string? registration_date { get; set; }
    }
}
