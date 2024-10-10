using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce.Models
{
    [Table("ProductCategories")]
    public class ProductCategory : BaseEntity
    {
        [Column(TypeName = "Name")]
        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Column(TypeName = "Description")]
        [DisplayName("Description")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
