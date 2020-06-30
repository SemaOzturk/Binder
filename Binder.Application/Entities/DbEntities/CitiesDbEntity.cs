using System.ComponentModel.DataAnnotations.Schema;

namespace Binder.Application.Entities.DbEntities
{
    public class CitiesDbEntity : IDbEntity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("state_id")]
        [ForeignKey("state_id")]
        public StatesDbEntity State { get; set; }
        // public int StateId { get; set; }
    }
}