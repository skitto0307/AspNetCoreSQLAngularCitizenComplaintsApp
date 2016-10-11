using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CitizenComplaintsAPI.Models.CitizenComplaints
{
    public class ComplaintDescription
    {
        public Guid ComplaintId { get; set; }
        public string Description { get; set; }
    }
}
