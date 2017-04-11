using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFLWeb.Models
{
    public class ClosedApplicationsModel
    {
        public IEnumerable<ClosedApplication> Applications { get; set; }
    }

    public class ClosedApplication : Application
    {   
        public DateTime AcceptedOn { get; set; }
    }
}
