namespace YangiHayot.Requests
{
    public class CreateOrderRequest
    {
        public int UserId {  get; set; }
        public int[] ProductIds { get; set; }
    }
}
