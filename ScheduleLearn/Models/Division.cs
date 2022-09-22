using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleLearnApi.Models
{
    [Table("Division")]
    public class Division
    {
        [Key]
        public string DivisionId { get; set; }

        [ForeignKey("HealhCenterId")]
        public string HealthCenterId { get; set; }
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
