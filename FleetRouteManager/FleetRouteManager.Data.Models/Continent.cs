using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FleetRouteManager.Data.Models
{
    public class Continent
    {
        [Key]
        [Comment("Primary key of Continent entity")]
        public int Id { get; set; }

        [Required]
        [MaxLength()]
        [Comment("Continent name")]
        public string Name { get; set; } = null!;
    }
}
