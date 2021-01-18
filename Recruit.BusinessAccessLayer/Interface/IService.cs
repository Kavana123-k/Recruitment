using System;
using System.Collections.Generic;
using System.Text;

namespace Recruit.BusinessAccessLayer.Interface
{
   public interface IService<T>
    {
        /// <summary>
        ///Generic Interface Method to get the contents from the DB WRT  Specified the primary key
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        T FindBy(int id);
        /// <summary>
        ///  Generic interface Method to get all the contents from the db
        /// </summary>
        /// <returns></returns>
        List<T> FindbyAll();
        /// <summary>
        /// Generic interface Method to perform the insert operation on the db table
        /// </summary>
        /// <param name="Entity">Entity which contains the values to be inserted</param>
        /// <returns></returns>
        string Insert(T Entity);
        /// <summary>
        ///  Generic interface Method to perform the Update operation on the db table
        /// </summary>
        /// <param name="Entity">Entity which contains the values to be inserted</param>
        /// <returns></returns>
        string Update(T Entity);
        /// <summary>
        ///  Generic interface Method to perform the Delete operation on the db table
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        bool Delete(int id);
        /// <summary>
        ///  Generic interface Method to perform the Delete operation on the db table
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        List<T> GetRequired(int id);


    }
}
