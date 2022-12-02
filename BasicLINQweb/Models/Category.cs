using System.ComponentModel.DataAnnotations;

namespace BasicLINQweb.Models
{
    public class Category
    {
        [Key]
        public int CategroyId { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        public ICollection<Vehicle> Vehicle { get; set; }
    }
}
