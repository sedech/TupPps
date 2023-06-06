

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels.Entities
{
    public class EntityBase
    {
        [Key]
        public Int64 Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public int State { get; set; }
    }
}
