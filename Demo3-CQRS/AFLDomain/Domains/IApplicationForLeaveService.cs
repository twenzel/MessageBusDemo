using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFLContracts.Messages;

namespace AFLDomain.Domains
{
    public interface IApplicationForLeaveService
    {
        void AcceptApplication(AcceptApplication message);
        void CreateApplicationRequest(ApplicationForLeave applicationForLeave);
    }
}
