namespace VeloWorldSystem.Models.Entities.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VeloWorldSystem.Models.Abstract;

    using static VeloWorldSystem.Common.Constants.DataConstants;

    public class Waypoint : BaseDeletableEntity<int>
    {
        [Required]
        [ForeignKey(nameof(Activity))]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; } = null!;

        [Required]
        public int OrderNumber { get; set; }

        [Required]
        [Precision(WaypointConstants.ActivityLatitudePrecision, WaypointConstants.ActivityLatitudeScale)]
        public decimal Latitude { get; set; }

        [Required]
        [Precision(WaypointConstants.ActivityLongitudePrecision, WaypointConstants.ActivityLongitudeScale)]
        public decimal Longitude { get; set; }

        [Required]
        public int Elevation { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public int Temperature { get; set; }
        
        public int? HeartRate { get; set; }

        [Precision(WaypointConstants.ActivitySpeedPrecision, WaypointConstants.ActivitySpeedScale)]
        public decimal Speed { get; set; }
    }
}
