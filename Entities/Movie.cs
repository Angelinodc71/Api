using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Models;

namespace Api.Entities
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required (ErrorMessage = "The \"name\" attribute is required")]
        [MaxLength(20, ErrorMessage = "MaxLength expected (20 characters)")]
        public string name { get; set; }
        
        [Required (ErrorMessage = "The \"description\" attribute is required")]
        [MaxLength(100, ErrorMessage = "MaxLength expected (20 characters)")]
        public string description { get; set; }

        public ICollection<Cast> Casts { get; set; } = new List<Cast>();
    }
}