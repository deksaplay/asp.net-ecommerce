using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce.Models
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
        public string? ImagePath { get; set; }
        public byte[]? ImageFile { get; set; }

        public int? ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }


    }
}