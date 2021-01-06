using Recruit.DataAccessLayer.Interface;
using Recruit.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Recruit.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IGenericRepository<Candidate> _candidateRepository;
        private readonly IGenericRepository<Location> _locationRepository;
        private readonly IGenericRepository<InterviewDetail> _interviewDetailRepository;
        private readonly IGenericRepository<InterviewRoundStatus> _interviewRoundStatusRepository;
        private readonly IGenericRepository<Source> _sourceRepository;
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<Vacancy> _vacancyRepository;
        private readonly IGenericRepository<Owner> _ownerRepository;
        private readonly IGenericRepository<ProcessStatus> _processStatusRepository;
        private readonly IGenericRepository<ProcessStage> _processStageRepository;
        
        public UnitOfWork(IGenericRepository<Candidate> candidateRepository,
                            IGenericRepository<Location> locationRepository,
                                IGenericRepository<InterviewDetail> interviewDetailRepository,
                                IGenericRepository<InterviewRoundStatus> interviewRoundStatusRepository,
                                IGenericRepository<Source> sourceRepository,
                                IGenericRepository<Employee> employeeRepository,
                                IGenericRepository<Vacancy> vacancyRepository,
                                IGenericRepository<Owner> ownerRepository,
                                IGenericRepository<ProcessStatus> processStatusRepository,
                                IGenericRepository<ProcessStage> processStageRepository
                                  
                                )
        {
            _candidateRepository = candidateRepository;
            _locationRepository = locationRepository;
            _interviewDetailRepository = interviewDetailRepository;
            _interviewRoundStatusRepository = interviewRoundStatusRepository;
            _sourceRepository = sourceRepository;
            _employeeRepository = employeeRepository;
            _vacancyRepository = vacancyRepository;
            _ownerRepository = ownerRepository;
            _processStatusRepository = processStatusRepository;
            _processStageRepository = processStageRepository;
            



        }

        //void IUnitOfWork.Complete()
        //{
        //    throw new NotImplementedException();
        //}

        public IGenericRepository<Candidate> candidateRepository
        {
            get
            {
                return _candidateRepository;
            }
        }
        public IGenericRepository<Location> locationRepository
        {
            get
            {
                return _locationRepository;
            }
        }
        public IGenericRepository<InterviewRoundStatus> interviewRoundStatusRepository
        {
            get
            {
                return _interviewRoundStatusRepository;
            }
        }
        public IGenericRepository<InterviewDetail> interviewDetailRepository
        {
            get
            {
                return _interviewDetailRepository;
            }
        }
        public IGenericRepository<ProcessStage> processStageRepository
        {
            get
            {
                return _processStageRepository;
            }
        }
        public IGenericRepository<ProcessStatus> processStatusRepository
        {
            get
            {
                return _processStatusRepository;
            }
        }

        public IGenericRepository<Vacancy> vacancyRepository
        {
            get
            {
                return _vacancyRepository;
            }
        }
        public IGenericRepository<Owner> ownerRepository
        {
            get
            {
                return _ownerRepository;
            }
        }
        public IGenericRepository<Employee> employeeRepository
        {
            get
            {
                return _employeeRepository;
            }
        }
        public IGenericRepository<Source> sourceRepository
        {
            get
            {
                return _sourceRepository;
            }
        }
     
    }

}
