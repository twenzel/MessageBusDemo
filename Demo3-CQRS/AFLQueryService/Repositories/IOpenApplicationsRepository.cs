using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFLQueryService.Models;

namespace AFLQueryService.Repositories
{
    public interface IOpenApplicationsRepository
    {
        void RemoveApplication(string applicationId);
        IEnumerable<OpenApplication> GetAll();
        void AddRequest(OpenApplication request);
    }
}
