namespace ADCD.Models
{
    public class Jobsite
    {
        public int JobsiteId { get; set; }
        public string JobsiteName { get; set; }
        public string Address { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
