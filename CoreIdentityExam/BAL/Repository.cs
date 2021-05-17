using CoreIdentityExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreIdentityExam.BAL
{
    public class Repository : IRepository
    {
        private readonly AppDBContext appDBContext;

        public Repository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public void Insert(UserDetails model)
        {
            appDBContext.userDetails.Add(model);
            appDBContext.SaveChanges();
        }
        public IEnumerable<UserDetails> GetAllUsers()
        {
            var model = appDBContext.userDetails.ToList();
            return model;
        }
        public UserDetails GetUserById(int id)
        {
            var user = appDBContext.userDetails.Find(id);
            return user;
        }

        public void Update(UserDetails userDetails)
        {
            var user = appDBContext.userDetails.Find(userDetails.Id);
            user.Name = userDetails.Name;
            user.Contact = userDetails.Contact;
            user.State = userDetails.State;
            appDBContext.SaveChanges();

        }
        public void Delete(int id)
        {
            var user = GetUserById(id);
            appDBContext.userDetails.Remove(user);
            appDBContext.SaveChanges();
        }
    }
}
