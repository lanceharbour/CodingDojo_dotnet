using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner
{
    public class Connection
    {
        [Key]
        public int ConnectionId { get; set; }

        [Required]
        public int UserId { get; set; }
        
        [Required]
        public int WeddingId { get; set; }
        
        public User User { get; set; }
        public Wedding Wedding { get; set; }
    }
}