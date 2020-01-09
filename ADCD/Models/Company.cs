using System.Collections.Generic;

namespace ADCD.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public List<Order> Orders { get; set; }
        public Contact Contact { get; set; }
    }
}
