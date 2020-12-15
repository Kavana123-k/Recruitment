using System;
using System.Collections.Generic;
using System.Text;

namespace Recruit.DataAccessLayer.Interface
{

    public interface IGenericRepository<TEntity> where TEntity : class
    {
       public TEntity Get(int id);
        List<TEntity> GetAll();
        string Add(TEntity entity);
        void Delete(TEntity entity);
        string Update(TEntity entity);
    }
}
