

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataModels.Entities
{
    public class EntityBase
    {
        [Key]
        public Int64 Id { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public DateTime? FinalDate { get; set; }
        [JsonIgnore]
        public int State { get; set; }
    }
}
