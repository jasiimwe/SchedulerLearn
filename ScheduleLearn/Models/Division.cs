using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleLearnApi.Models
{
    [Table("Division")]
    public class Division
    {
        [Key]
        public string Id { get; set; }
        public string HealthCenterId { get; set; }
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
