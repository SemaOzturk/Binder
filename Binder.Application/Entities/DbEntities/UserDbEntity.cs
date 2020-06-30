using System;
using System.Collections.Generic;
using System.Text;

namespace Binder.Application.Entities.DbEntities
{
    public class UserDbEntity : IDbEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Sex { get; set; }
        public Zodiac Zodiac { get; set; }
        public ICollection<Image> Images { get; set; }
        public DateTime LastOnlineDate { get; set; }
        public CountryDbEntity Country { get; set; }
        public StatesDbEntity States { get; set; }
        public CitiesDbEntity City { get; set; }
        public string Bio { get; set; }

    }
}
