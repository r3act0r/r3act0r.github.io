using System;

namespace ADCD.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CraneId { get; set; }
        public int CompanyId { get; set; }
        public Crane Crane { get; set; }
        public Company Company { get; set; }
        public Jobsite Jobsite { get; set; }
    }
}
