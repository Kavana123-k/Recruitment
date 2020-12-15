using System;
using System.Collections.Generic;
using System.Text;
using Recruit.DataAccessLayer.Interface;
using Recruit.Models;

namespace ConsoleApp1
{
   public  class test
    {
        private IUnitOfWork unitOfWork;

        static Recruit.BusinessAccessLayer.Interface.IService<Candidate> _service;
        public test(Recruit.BusinessAccessLayer.Interface.IService<Candidate> service)
        {
            _service = service;
        }


        public void Testme()
        {
            var data = _service.FindbyAll();
        }
    }
}
