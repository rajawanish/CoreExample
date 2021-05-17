using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreIdentityExam.Data
{
  public interface IRepositoryGeneric<T> where T : class
    {
        /// <summary>
        /// It is use to fetch all records form database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAll();

        
        /// <summary>
        /// It is used to fetch a single record based on given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetById(object id);

        /// <summary>
        /// It is used to insert user data in database
        /// </summary>
        /// <param name="obj"></param>
        void Insert(T obj);

        /// <summary>
        /// It is used to update user record
        /// </summary>
        /// <param name="obj"></param>
        void Update(T obj);

     /// <summary>
     /// It is used to delete user record
     /// </summary>
     /// <param name="id"></param>
        void Delete(object id);

        
        /// <summary>
        /// This method is used for saveChange
        /// </summary>
        void Save();
    }
}
