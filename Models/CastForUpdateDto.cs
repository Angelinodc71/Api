using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class CastForUpdateDto
    {
        [Required (ErrorMessage = "El nombre es requerido")]
        [MaxLength(20, ErrorMessage = "MaxLength expected, 20")]
        public string name { get; set; }
        [Required]
        [MaxLength(20)]
        public string character { get; set; }
    }
}