using AFLDomain.Domains;

namespace AFLDomain.Repositories
{
    public interface IApplicationForLeaveRepository
    {
        ApplicationForLeave GetApplication(string applicationId);

        void Update(ApplicationForLeave application);
        void Add(ApplicationForLeave application);
    }
}