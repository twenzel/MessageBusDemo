using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFLDomain.Domains
{
    public class ApplicationForLeave
    {
        public string Id { get; set; }
        public string Requester { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime AcceptedOn { get; set; }
    }
}
