using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFLDomain.Domains;
using Microsoft.AspNetCore.Mvc;

namespace AFLDomain.Controllers
{
    [Route("api/[controller]")]
    public class ApplicationsController : Controller
    {
        private IApplicationForLeaveService _service;        

        public ApplicationsController(IApplicationForLeaveService service)
        {
            _service = service;
        }

        [HttpGet("test")]        
        public IActionResult Test()
        {
            _service.CreateApplicationRequest(new ApplicationForLeave() {               
                Requester = "Peter Mayhew",
                From = DateTime.Today.AddDays(15),
                To = DateTime.Today.AddDays(18)
            });

            _service.CreateApplicationRequest(new ApplicationForLeave()
            {          
                Requester = "Kenny Baker",
                From = DateTime.Today.AddDays(20),
                To = DateTime.Today.AddDays(30)           
            });

            _service.CreateApplicationRequest(new ApplicationForLeave()
            { 
                Requester = "Anthony Daniels",
                From = DateTime.Today.AddDays(21),
                To = DateTime.Today.AddDays(30)
            });

            _service.CreateApplicationRequest(new ApplicationForLeave()
            {
                Requester = "Peter Cushing",
                From = DateTime.Today.AddDays(120),
                To = DateTime.Today.AddDays(129)
            });

            _service.CreateApplicationRequest(new ApplicationForLeave()
            {
                Requester = "Alec Guinness",
                From = DateTime.Today.AddDays(125),
                To = DateTime.Today.AddDays(133)
            });

            return Ok();
        }
    }
}
