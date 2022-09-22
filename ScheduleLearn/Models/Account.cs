using Microsoft.EntityFrameworkCore;
using ScheduleLearnApi.Models.Persistent;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleLearnApi.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public string AccountId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime Date { get; set; }
    }
}
