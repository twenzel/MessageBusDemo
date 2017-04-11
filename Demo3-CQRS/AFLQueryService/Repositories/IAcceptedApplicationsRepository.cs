using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFLQueryService.Models;

namespace AFLQueryService.Repositories
{
    public interface IAcceptedApplicationsRepository
    {
        void AddApplication(AcceptedApplication acceptedApplication);
        IEnumerable<AcceptedApplication> GetAll();
    }
}
