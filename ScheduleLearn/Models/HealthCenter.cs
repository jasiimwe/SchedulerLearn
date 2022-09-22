using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleLearnApi.Models
{
    [Table("HealthCenter")]
    public class HealthCenter
    {
        [Key]
        public string HealthCenterId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        [ForeignKey("DirectorId")]
        public string? DirectorId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
