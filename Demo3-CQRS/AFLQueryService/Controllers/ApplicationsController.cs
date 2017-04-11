using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFLQueryService.Models;
using AFLQueryService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AFLQueryService.Controllers
{
    [Route("api/[controller]")]
    public class ApplicationsController : Controller
    {
        private IOpenApplicationsRepository _openRepository;
        private IAcceptedApplicationsRepository _acceptedRepository;

        public ApplicationsController(IOpenApplicationsRepository openRepository, IAcceptedApplicationsRepository acceptedRepository)
        {
            _openRepository = openRepository;
            _acceptedRepository = acceptedRepository;
        }

        [HttpGet("open")]
        public IEnumerable<OpenApplication> Open()
        {
            return _openRepository.GetAll();
        }

        [HttpGet("accepted")]
        public new IEnumerable<AcceptedApplication> Accepted()
        {
            return _acceptedRepository.GetAll();
        }
    }
}
