using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CitizenComplaintsAPI.Models.CitizenComplaints
{
    public class Citizen
    {
        public Guid CitizenId { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }


        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateId { get; set; }
        public string ZipCode { get; set; }

        //Day, evening and fax could be broken down into seperate table by 
        //type, value and availability Type
        public string PhoneDay { get; set; }
        public string PhoneEvening { get; set; }
        public string PhoneFax { get; set; }
        public string Email { get; set; }


        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public bool Enabled { get; set; }

        
       
    }
}
