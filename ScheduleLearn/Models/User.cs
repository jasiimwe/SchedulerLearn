using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleLearnApi.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// 
        /// </summary>
        public string? AccountId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? WardId { get; set; }

        /// <summary>
        /// 
        /// </summary>
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
