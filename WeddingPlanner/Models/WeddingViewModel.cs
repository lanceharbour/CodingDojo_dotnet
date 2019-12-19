using System.Collections.Generic;

namespace WeddingPlanner
{
    public class WeddingViewModel
    {
        public User User { get; set; }
        public List<Wedding> Weddings { get; set; }
        public Connection Connection { get; set; }
    }
}