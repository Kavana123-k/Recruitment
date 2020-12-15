using System;
using Recruit.BusinessAccessLayer;
using Recruit.DataAccessLayer;
using Recruit.DataAccessLayer.Interface;
using Recruit.Models;

namespace ConsoleApp1
{
    class Program
    {
        private readonly IGenericRepository<Candidate> _candidateRepository;
       // private readonly IGenericRepository<Candidate> _candidateRepository;

        public Program()
        {
           
        }

        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            //var uow=new UnitOfWork()

            //  var data=unitOfWork.candidateRepository.GetAll();
            // _service=new CandidateService(unitOfWork);

            var canService=new CandidateService(new UnitOfWork(new GenericRepository<Candidate>()));
            var t = new test(canService);
            t.Testme();



        }
    }
}
