using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleLearnApi.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public string UserId { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("AccountId")]
        public string? AccountId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("WardId")]
        public string? WardId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// 
        [ForeignKey("CreatedId")]
        public string? CenterId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Contact { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? MedicalIssues { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? MaritalStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Profession { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DoB { get; set; }

        public string? HeighestLvlEducaTION { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
