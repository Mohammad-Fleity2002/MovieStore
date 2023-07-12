using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models
{
    public class Categories
    {
        [Key]
        public int category_id { get; set; }
        public string category_title { get; set; }
    }
}
