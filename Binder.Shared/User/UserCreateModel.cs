using System;
using System.Collections.Generic;
using System.Text;

namespace Binder.Shared.User
{
    public class UserCreateModel
    {
       
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        // public ICollection<Image> Images { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string Bio { get; set; }
    }
}
