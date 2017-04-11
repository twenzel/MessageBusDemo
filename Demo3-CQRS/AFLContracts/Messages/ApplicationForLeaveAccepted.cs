using System;
using System.Collections.Generic;
using System.Text;

namespace AFLContracts.Messages
{
    public class ApplicationForLeaveAccepted
    {
        public string Requester { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string ApplicationId { get; set; }
        public DateTime AcceptedOn { get; set; }
    }
}
