namespace YangiHayot.Responses
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        public string Photo { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
