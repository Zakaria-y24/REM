using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{

    [Route("application")] 

    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantDAO applicants;

        public ApplicantController(IApplicantDAO applicants)
        {
            this.applicants = applicants;
        }


        [HttpPost]
        [Authorize]
        public ActionResult AddApplication(Applicant applicant)
        {

            int userId = int.Parse(this.User.FindFirst("sub").Value);


            Applicant addedApplicant = applicants.AddApplicant(userId, applicant);

            return Created("/application/" + addedApplicant.ApplicantId, addedApplicant);

        }
        [HttpGet]
        [Authorize]
        public ActionResult GetMyApplications()
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);

            IEnumerable<Applicant> results = applicants.GetAllApplicants(userId);

            return Ok(results);
        }
        [HttpPut("accept")]
        [Authorize(Roles = "admin")]
        public ActionResult AcceptApplication(Applicant application)
        {
            var results = applicants.AcceptApplication(application);

            return Ok(results);
        }
        [HttpPut("deny")]
        [Authorize(Roles = "admin")]
        public ActionResult DenyApplication(Applicant application)
        {
            var results = applicants.DenyApplication(application);

            return Ok(results);
        }
        [HttpGet("properties")]
        [Authorize(Roles = "admin")]
        public ActionResult OwnerGetApplications()
        {
            int userId = int.Parse(this.User.FindFirst("sub").Value);

            IEnumerable<Applicant> results = applicants.OwnerGetAllApplicants(userId);

            return Ok(results);
        }



    }
}
