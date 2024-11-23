using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FleetRouteManager.Common.Constants.ContinentConstants;

namespace FleetRouteManager.Data.Models
{
    public class Continent
    {
        [Key]
        [Comment("Primary key of Continent entity")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Continent name")]
        public string Name { get; set; } = null!;
    }
}
