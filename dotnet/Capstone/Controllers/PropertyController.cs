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
    [Route("properties")] 
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyDAO properties;

        public PropertyController(IPropertyDAO properties)
        {
            this.properties = properties;
        }

        [HttpGet] 
        [AllowAnonymous]
        public ActionResult GetAllMattisms()
        {
            IEnumerable<Property> results = properties.GetAllProperties();

            return Ok(results);
        }


    }
}