using MessagePack;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleLearnApi.Models
{
    [Table("Director")]
    public class Director
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string DirectorId { get; set; }
        
        [ForeignKey("AccountId")]
        public string AccountId { get; set; }
        public string Name { get; set; }

        public DateTime Dob { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool isDeleted { get; set; }

    }
}
