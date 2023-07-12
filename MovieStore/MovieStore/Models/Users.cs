using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models
{
    public class Users
    {
        [Key]
        public int user_id { get; set; }

        public string user_first_name { get; set; }

        public string user_middle_name { get; set; }

        public string user_last_name { get; set; }

        public string user_email { get; set; }

        public string user_password { get; set; }

        public string user_phone_number { get; set; }
        [DataType(DataType.Date)]
        public DateTime user_join_date { get; set; } = DateTime.Today;

        public virtual int role { get; set; }
        [ForeignKey("role_name")]
        public virtual User_Roles user_role { get; set; }
    }
}
