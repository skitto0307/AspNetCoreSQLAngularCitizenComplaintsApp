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
    public class LookupsController : Controller
    {

        CitizenComplaintsContext db;

        public LookupsController(CitizenComplaintsContext context)
        {
            db = context;
        }

        // GET: api/lookups list
        [HttpGet]
        public JsonResult Get()
        {
            return Json(new {
                IssueTypes = db.IssueTypes.ToList()
            });
        }

       
    }
}
