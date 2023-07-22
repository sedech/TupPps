using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels.Entities
{
    public class Order:EntityBase
    {


        public required string UserId { get; set; }
        public Int64 OrderItemId { get; set; }
        public float Total { get; set; }

    }
}
