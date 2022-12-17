using BasicLINQweb.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BasicLINQweb.ViewModel
{
    public class VehicleViewModel
    {
        [Key]
        public int vehicleId { get; set; }

        [Required]
        [Display(Name = "Engine Id")]
        public string EngId { get; set; }

        [Required]
        [Display(Name = "Purchase Date")]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [Display(Name = "Current Status")]
        public string CurrStatus { get; set; }

        public IFormFile? Picture { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]

        public Category? Category { get; set; }
    }
}
