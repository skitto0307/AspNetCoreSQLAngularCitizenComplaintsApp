using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitizenComplaintsAPI.Models.CitizenComplaints
{
    public class LocationAddress
    {
        public Guid LocationAddressId { get; set; }
        public Guid ComplaintId { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateId { get; set; }
        public string ZipCode { get; set; }
        //lat 
        //long
    }
}
