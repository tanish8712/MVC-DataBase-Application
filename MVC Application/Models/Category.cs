using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_Application.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName(" Display Order")]
        [Range(1,100,ErrorMessage ="Enter Between 1 to 100 only")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
