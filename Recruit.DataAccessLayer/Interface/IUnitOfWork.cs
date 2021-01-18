using Recruit.Models;

namespace Recruit.DataAccessLayer.Interface
{
    public interface IUnitOfWork
    {
        IGenericRepository<Candidate> candidateRepository { get; }
        IGenericRepository<Location> locationRepository { get; }
        IGenericRepository<Employee> employeeRepository { get; }
        IGenericRepository<InterviewDetail> interviewDetailRepository { get; }
        IGenericRepository<InterviewRoundStatus> interviewRoundStatusRepository { get; }
        IGenericRepository<Owner> ownerRepository { get; }
        IGenericRepository<ProcessStage> processStageRepository { get; }
        IGenericRepository<ProcessStatus> processStatusRepository { get; }
        IGenericRepository<Source> sourceRepository { get; }
        IGenericRepository<Vacancy> vacancyRepository { get; }
        IGenericRepository<Timeline> timelineRepository { get; }





    }
}