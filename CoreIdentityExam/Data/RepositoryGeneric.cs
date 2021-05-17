using CoreIdentityExam.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreIdentityExam.Data
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        private readonly AppDBContext _appDBContext;
        private DbSet<T> entity;

        public RepositoryGeneric(AppDBContext appDBContext)
        {
            this._appDBContext = appDBContext;
            entity = _appDBContext.Set<T>();
        }

        /// <summary>
        /// It fetch all the records from database
        /// </summary>
        /// <returns>All the Records</returns>
        public async Task<IEnumerable<T>> GetAll()
        {
           return await entity.ToListAsync();
        }

        /// <summary>
        /// Fetch record based on given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>It returns the user record</returns>
        public async Task<T> GetById(object id)
        {
           return await entity.FindAsync(id);
        }

        /// <summary>
        /// This function is used to insert user records  
        /// </summary>
        /// <param name="obj"></param>
        public void Insert(T obj)
        {
           entity.Add(obj);
        }


        /// <summary>
        /// It is used to update user records
        /// </summary>
        /// <param name="obj"></param>
        public void Update(T obj)
        {
            entity.Attach(obj);
            _appDBContext.Entry(obj).State = EntityState.Modified;
        }


        /// <summary>
        /// It is used to delete user record
        /// </summary>
        /// <param name="id"> where id is user id</param>
        public void Delete(object id)
        {
            T existing = entity.Find(id);
            entity.Remove(existing);
        }


        /// <summary>
        /// This function is used to save the changes in database
        /// </summary>
        public void Save()
        {
            _appDBContext.SaveChanges();
        }

    }
}
