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
    [Route("properties")] // properties
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyDAO properties;

        public PropertyController(IPropertyDAO properties)
        {
            this.properties = properties;
        }

      [HttpPost]
      [Authorize]

      public ActionResult AddProperty(Property property)
        {
            Property newProperty = properties.Create(property);

            string location = $"properties/{newProperty.Id}";

            return Created(location,newProperty);
        }

        
    }
}