namespace e_commerce.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string UserType { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
    }
}