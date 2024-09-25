namespace e_commerce.Models
{
    public class Review : BaseEntity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}