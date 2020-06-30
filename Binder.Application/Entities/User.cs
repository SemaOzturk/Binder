using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Binder.Application.Entities
{
    public class User
    {
        private static readonly ZodiacManager _zodiacManager = new ZodiacManager(); 
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        private DateTime _birthdate;
        public DateTime BirthDate
        {
            get { return _birthdate; }
            set
            {
                _birthdate = value;
                Zodiac = _zodiacManager.FindZodiac(BirthDate);
            }
        } 
        public Gender Sex { get; set; }
       public Zodiac Zodiac { get; set; }
       public bool IsOnline { get; set; }
       public ICollection<Image> Images { get; set; }
       public DateTime LastOnlineDate { get; set; }
       public Country Country { get; set; }
       public State State { get; set; }
       public City City { get; set; }
       public string Bio { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
    public class Zodiac
    {
        public int Id { get; set; }
        public ZodiacSigns Sign { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public enum ZodiacSigns
    {
        Aquarius,
        Pisces,
        Aries,
        Taurus,
        Gemini,
        Cancer,
        Leo,
        Virgo,
        Libra,
        Scorpio,
        Sagittarius,
        Capricorn
    }
    public class ZodiacManager
    {
        private readonly Dictionary<Zodiac, Zodiac> _zodiacs = new Dictionary<Zodiac, Zodiac>(new ZodiacComparer());
        public ZodiacManager()
        {
            AddZodiac(ZodiacSigns.Aquarius, new DateTime(1, 1, 20), new DateTime(1, 2, 18));
            AddZodiac(ZodiacSigns.Pisces, new DateTime(1, 2, 19), new DateTime(1, 3, 19));
            AddZodiac(ZodiacSigns.Taurus, new DateTime(1, 4, 20), new DateTime(1, 5, 20));
            AddZodiac(ZodiacSigns.Aries, new DateTime(1, 3, 21), new DateTime(1, 4, 19));
            AddZodiac(ZodiacSigns.Gemini, new DateTime(1, 5, 21), new DateTime(1, 6, 20));
            AddZodiac(ZodiacSigns.Cancer, new DateTime(1, 6, 21), new DateTime(1, 7, 22));
            AddZodiac(ZodiacSigns.Leo, new DateTime(1, 7, 23), new DateTime(1, 8, 22));
            AddZodiac(ZodiacSigns.Virgo, new DateTime(1, 8, 23), new DateTime(1, 9, 22));
            AddZodiac(ZodiacSigns.Libra, new DateTime(1, 9, 23), new DateTime(1, 10, 22));
            AddZodiac(ZodiacSigns.Scorpio, new DateTime(1, 10, 23), new DateTime(1, 11, 21));
            AddZodiac(ZodiacSigns.Sagittarius, new DateTime(1, 11, 22), new DateTime(1, 12, 21));
            AddZodiac(ZodiacSigns.Capricorn, new DateTime(1, 12, 22), new DateTime(1, 1, 19));
        }
        private void AddZodiac(ZodiacSigns sign, DateTime startDate, DateTime endDate)
        {
            Zodiac zodiac = new Zodiac();
            zodiac.Sign = sign;
            zodiac.StartDate = startDate;
            zodiac.EndDate = endDate;
            _zodiacs.Add(zodiac, zodiac);
        }
        public Zodiac FindZodiac(DateTime date)
        {
            date = new DateTime(1, date.Month, date.Day);
            return _zodiacs.FirstOrDefault(x => x.Value.StartDate < date && x.Value.EndDate > date).Value;
        }
    }
    /// <summary>
    /// hasleme yapmak istediğimiz alanı belirledik.Key olmasını istediğimiz
    /// </summary>
    public class ZodiacComparer : IEqualityComparer<Zodiac>
    {
        public bool Equals(Zodiac x, Zodiac y)
        {
            return x.Sign == y.Sign;
        }
        public int GetHashCode(Zodiac obj)
        {
            return obj.Sign.GetHashCode();
        }
    }

    public class CommonInterest
    {
        public int Id { get; set; }
    }

}
