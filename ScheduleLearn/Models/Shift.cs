using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleLearnApi.Models
{
    [Table("Shift")]
    public class Shift
    {
        [Key]
        public string ShiftId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("WardId")]
        public string WardId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan StartTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan EndTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int StartDay { get; set; }
        public int EndDay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
