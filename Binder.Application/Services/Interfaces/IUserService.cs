using System;
using System.Collections.Generic;
using System.Text;
using Binder.Application.Entities;
using Binder.Shared.User;

namespace Binder.Application.Services
{
    public interface IUserService
    {
        public User CheckForLogin(string userName, string password);
        public User GetUser(int id);
        public User CreateUser(User user,string password);
        public IEnumerable<string> GetGender();
        public IEnumerable<User> ShowAround(int cityId);
    }
}
