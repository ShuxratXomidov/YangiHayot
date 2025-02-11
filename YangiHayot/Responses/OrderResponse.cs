namespace YangiHayot.Responses
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } 
        public int UserId { get; set; }
        public decimal TotalSum {  get; set; }
    }
}
