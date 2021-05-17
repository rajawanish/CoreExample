using CoreIdentityExam.Models;
using System.Collections.Generic;

namespace CoreIdentityExam.BAL
{
    public interface IRepository
    {
        void Delete(int id);
        IEnumerable<UserDetails> GetAllUsers();
        UserDetails GetUserById(int id);
        void Insert(UserDetails model);
        void Update(UserDetails userDetails);
    }
}