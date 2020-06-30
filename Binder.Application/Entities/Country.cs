using System;
using System.Collections.Generic;
using System.Text;
namespace Binder.Application.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string SortName { get; set; }
        public string Name { get; set; }
        public int PhoneCode { get; set; }
    }
}
