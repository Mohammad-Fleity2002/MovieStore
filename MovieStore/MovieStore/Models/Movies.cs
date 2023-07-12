using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Models
{
    public class Movies
    {
        [Key]
        public int movie_id { get; set; }

        public string movie_name { get; set; }

        public string movie_desc { get; set; }

        public int movie_quantity { get; set; }
        public int movie_price { get; set; }

        [DataType(DataType.Date)]
        public DateTime movie_add_date { get; set; }
        public virtual int categorie_id { get; set; }
        [ForeignKey("category_title")]
        public virtual Categories categories { get; set; }
    }
}
