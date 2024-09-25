using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class Category : BaseEntity
    {
        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [DisplayName("Description")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; }
    }
}
