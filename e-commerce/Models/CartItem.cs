using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce.Models
{
    [Table("CartItems")]
    public class CartItem : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        
       
    }
}