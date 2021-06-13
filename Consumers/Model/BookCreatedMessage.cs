namespace BooksApi.Consumers.Model
{
    public class BookCreatedMessage
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public string ToAddress { get; set; }
    }
}