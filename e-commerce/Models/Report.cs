using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class Report : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public string Content { get; set; }
        [Required]
        public DateTime ReportDate { get; set; }
    }
}