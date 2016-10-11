using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitizenComplaintsAPI.Models.CitizenComplaints
{
    public static class CitizenComplaintsExtensions
    {
        public static void SeedData(this CitizenComplaintsContext context) {

            if (context.AllMigrationsApplied()) {

                //Add default IssueTypes if none exist
                if (!context.IssueTypes.Any()) {    
                    context.IssueTypes.AddRange(
                          new IssueType { DisplayName = "Hazardous Material" },
                          new IssueType { DisplayName = "Animal in Park" },
                          new IssueType { DisplayName = "Construction" },
                          new IssueType { DisplayName = "Blocked Driveway" },
                          new IssueType { DisplayName = "Building Condition" },
                          new IssueType { DisplayName = "Rodent" },
                          new IssueType { DisplayName = "Street Light" },
                          new IssueType { DisplayName = "Street Condition" },
                          new IssueType { DisplayName = "Street Sign Missing" },
                          new IssueType { DisplayName = "Sewer" },
                          new IssueType { DisplayName = "Graffiti" },
                          new IssueType { DisplayName = "Noise" },
                          new IssueType { DisplayName = "Illegal Parking" },
                          new IssueType { DisplayName = "Unlicensed Dog" },
                          new IssueType { DisplayName = "Genteral Construction" },
                          new IssueType { DisplayName=  "Hazardous Material"},
                          new IssueType { DisplayName = "Public Toilet" },
                          new IssueType { DisplayName = "General" }
                        );
                    context.SaveChanges();
                }

               
                //Test Complaint
                if (!context.Complaints.Any()) {

                    var _issue = context.IssueTypes.Where(i => i.DisplayName == "Unlicensed Dog").Single();

                    var _complaintant = 
                        context.Citizens.Add(new Citizen {
                            CitizenId = Guid.NewGuid(),
                            FirstName = "Donald",
                            LastName = "Duck",
                            Address = "14 way Pond Drive",
                            City = "Duckburg",
                            StateId = "CA",
                            ZipCode = "93702", 
                            PhoneDay = "5555555555",

                    }).Entity;

                    var _complaint = 
                        context.Complaints.Add(new Complaint {
                            ComplaintId = Guid.NewGuid(),
                            CitizenId = _complaintant.CitizenId,
                            IssueTypeId = _issue.IssueTypeId
                        }).Entity;

                    var _complaintDescription = 
                        context.ComplaintDescriptions.Add(new ComplaintDescription {
                            ComplaintId = _complaint.ComplaintId,
                            Description = "Neighbor does not have a collar."
                        });

                    var _complaintLocation =
                        context.LocationAddresses.Add(new LocationAddress
                        {
                              LocationAddressId = Guid.NewGuid(),
                               ComplaintId = _complaint.ComplaintId,
                               Address  = "16 way pond Drive",
                               City = "Duckburg",
                               StateId = "CA",
                               ZipCode = "93702"
                        });

                    context.SaveChanges();

                }
            }
        }
    }
}
