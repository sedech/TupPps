namespace BussnessEntities
{
    public class OrderBe:EntityBaseBe
    {

        public required string UserId { get; set; }
        public Int64 OrderItemId { get; set; }
        public float Total { get; set; }
    }
}
