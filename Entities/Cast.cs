using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
    public class Cast
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required (ErrorMessage = "The \"name\" attribute is required")]
        [MaxLength(20, ErrorMessage = "MaxLength expected (20 characters)")]
        public string name { get; set; }
        [Required (ErrorMessage = "The \"character\" attribute is required")]
        [MaxLength(20, ErrorMessage = "MaxLength expected (20 characters)")]
        public string character { get; set; }

        [ForeignKey("movieId")]
        public Movie Movie { get; set; }

        public int movieId { get; set; }
    }
}