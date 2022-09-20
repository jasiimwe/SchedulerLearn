using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleLearnApi.Models
{
    [Table("HealthCenter")]
    public class HealthCenter
    {
        [Key]
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public string? Director { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
