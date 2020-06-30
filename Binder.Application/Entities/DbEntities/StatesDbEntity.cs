using System.ComponentModel.DataAnnotations.Schema;

namespace Binder.Application.Entities.DbEntities
{
    public class StatesDbEntity : IDbEntity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("country_id")]
        [ForeignKey("country_id")]
        public CountryDbEntity Country { get; set; }
    }
}