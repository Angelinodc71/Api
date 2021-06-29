using System.Collections.Generic;

namespace Api.Models
{
    public class MovieDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public ICollection<CastDto> Casts { get; set; } = new List<CastDto>();
    }
}