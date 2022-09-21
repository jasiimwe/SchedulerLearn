using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleLearnApi.Models
{
    [Table("Ward")]
    public class Ward
    {
        
        [Key]
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DivisionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CenterId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string InchargeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NumberOfWorkers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MinimunHoursAday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MaximumHoursAday { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
