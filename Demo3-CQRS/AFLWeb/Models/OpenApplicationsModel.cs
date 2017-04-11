using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFLWeb.Models
{
    public class OpenApplicationsModel
    {
        public IEnumerable<Application> Applications { get; set; }
    }

    public class Application
    {
        public string Requester { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string ApplicationId { get; set; }
    }
}
