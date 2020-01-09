namespace ADCD.Models
{
    public class Crane
    {
        public int CraneId { get; set; }
        public string CraneType { get; set; }
        public string Capacity { get; set; }
        public string BoomLength { get; set; }
        public string JibLength { get; set; }
        public string PerHourRate { get; set; }
        public string Image { get; set; }
        public Order Order { get; set; }
    }
}
