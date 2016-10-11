using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CitizenComplaintsAPI.Models.CitizenComplaints;
using Microsoft.EntityFrameworkCore;

namespace CitizenComplaintsAPI.Controllers
{
    [Route("api/[controller]")]
    public class ComplaintsController : Controller
    {
        CitizenComplaintsContext db;

        public ComplaintsController(CitizenComplaintsContext context)
        {
            db = context;
        }

        // GET: api/complaints list
        [HttpGet]
        public JsonResult Get()
        {
            return Json(db.Complaints
                            .Where(c=> c.Enabled)
                            .Include(c=> c.Description)
                            .Include(c=> c.LocationAddresses)
                            .Include(c=> c.Citizen)
                            .Include(c=> c.Issue));
        }

        // GET api/complaints/e4a25cfba821fb347046d9887a2 single
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var _complaint = db.Complaints
                            .Where(c=> c.ComplaintId.Equals(id))
                            .Include(c => c.Description)
                            .Include(c=> c.LocationAddresses)
                            .Include(c=> c.Issue)
                            .Include(c => c.Citizen).SingleOrDefault();

            if (_complaint == null)
            {
                return NotFound(Json(new { }));
            }
            
            return Ok(Json(_complaint));

        }

        // POST api/complaints update
        [HttpPost]
        public JsonResult Post([FromBody]Complaint complaint)
        {

            db.Update(complaint);
            db.SaveChanges();

            return Json(complaint);
        }

        // PUT api/complaints add
        [HttpPut]
        public JsonResult Put([FromBody]Complaint complaint)
        {
            db.Add(complaint);
            db.SaveChanges();

            return Json(complaint);
        }


    }
}
