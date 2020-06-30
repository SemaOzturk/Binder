using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Binder.Application.Entities.DbEntities
{
    public class CountryDbEntity : IDbEntity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("sortname")]
        public string SortName { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("phonecode")]
        public int PhoneCode { get; set; }
         
    }
}
