using Microsoft.EntityFrameworkCore;
using ScheduleLearnApi.Models.Persistent;
namespace ScheduleLearnApi.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime Date { get; set; }
    }
}
