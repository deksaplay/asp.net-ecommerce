using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce.Models
{
    public class Customer : BaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public virtual User User { get; set; }
    }
}