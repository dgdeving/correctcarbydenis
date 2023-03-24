using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorrectCar.Models
{
    public class VideoURL
    {
        public int Id { get; set; }
        [ValidateNever]
        [DisplayName("Video")]
        public string VideoUrl { get; set; }
        [Required]
        [DisplayName("Product")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }
    }
}
