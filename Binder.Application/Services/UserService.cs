using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Binder.Application.Entities;
using Binder.Application.Entities.DbEntities;
using Binder.Application.Repositories;
using Binder.Shared.User;
namespace Binder.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserDbEntity> _userRepository;
        public UserService(IRepository<UserDbEntity> userRepository)
        {
            _userRepository = userRepository;
        }
        public User CheckForLogin(string userName, string password)
        {
            UserDbEntity existUser = _userRepository.GetAll()
                .FirstOrDefault(x => x.UserName == userName && x.Password == password);
            User user = new User
            {
                UserName = existUser.UserName,
                Id = existUser.Id,
                LastOnlineDate = DateTime.Now
            };
            return user;
        }
        public User GetUser(int id)
        {
            var userDb = _userRepository.GetById(id);
            User user = Build(userDb);
            return user;
        }
        public User CreateUser(User user, string password)
        {
            var userDb = Build(user, password);
            _userRepository.Add(userDb);
            var newUser = Build(userDb);
            return newUser;
        }
        public IEnumerable<string> GetGender()
        {
            var sx = new List<string>();
            foreach (Gender suit in (Gender[])Enum.GetValues(typeof(Gender)))
            {
                sx.Add(suit.ToString());
            }

            return sx;
        }

        public IEnumerable<User>  ShowAround(int cityId)
        {
            return _userRepository.GetAll().Where(x => x.City.Id == cityId).Select(userDb => Build(userDb));
        }
    
        private static UserDbEntity Build(User user, string password)
        {
            //Kullanıcının doldurduğu alanlar.
            var userDb = new UserDbEntity
            {
                NickName = user.NickName,
                Email = user.Email,
                UserName = user.UserName,
                Password = password,
                BirthDate = user.BirthDate,
                Sex = user.Sex,
                Zodiac = user.Zodiac,
                Images = user.Images,
            };
            return userDb;
        }
        private static User Build(UserDbEntity userDbEntity)
        {
            User user = new User();
            user.Email = userDbEntity.Email;
            user.Id = userDbEntity.Id;
            user.UserName = userDbEntity.UserName;
            user.NickName = userDbEntity.NickName;
            user.BirthDate = userDbEntity.BirthDate;
            user.Bio = userDbEntity.Bio;
            //  user.City = userDbEntity.City.
            return user;
        }

        //private City Build(CitiesDbEntity citiesDb)
        //{
        //    City city = new City();
        //    city.Id = citiesDb.Id;
        //    city.Name = citiesDb.Name;
        //    city.
        //}
    }
}
