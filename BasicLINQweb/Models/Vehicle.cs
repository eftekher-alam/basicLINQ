using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicLINQweb.Models
{
    public class Vehicle
    {
        [Key]
        public int vehicleId { get; set; }

        [Required]
        [Display(Name = "Engine Id")]
        public string EngId { get; set; }

        [Required]
        [Display(Name = "Purchase Date")]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString ="{yyyy-MM-dd}")]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [Display(Name = "Current Status")]
        public string CurrStatus { get; set; }

        public string Picture { get; set; }

        [Display(Name ="Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]

        public Category Category { get; set; }
    }
}
