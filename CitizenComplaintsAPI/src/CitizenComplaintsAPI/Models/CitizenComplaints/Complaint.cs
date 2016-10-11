using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitizenComplaintsAPI.Models.CitizenComplaints
{
    public class Complaint
    {
        public Guid ComplaintId { get; set; }
        public Guid CitizenId { get; set; }
        public int IssueTypeId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public Boolean Enabled { get; set; }

        //Child Entities
        //public IssueType Issue { get; set; }
        public IssueType Issue { get; set; }
        public Citizen Citizen { get; set; }
        public ComplaintDescription Description { get; set; }
        public List<LocationAddress> LocationAddresses { get; set; }

    

    }
}
