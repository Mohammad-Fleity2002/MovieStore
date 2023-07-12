using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models
{
    public class User_Roles
    {
        [Key]
        public int role_id { get; set; }
        public string role_name { get; set; }

    }
}
