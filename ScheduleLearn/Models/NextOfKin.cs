using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleLearnApi.Models
{
    [Table("Next of Kin")]
    public class NextOfKin
    {
        [Key]
        public string NextOfKinId { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey("UserId")]
        public string UserID { get; set; } 
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relationship { get; set; }
        public string Contact { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
