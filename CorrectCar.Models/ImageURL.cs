using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorrectCar.Models
{
    public class ImageURL
    {
        public int Id { get; set; }
        [ValidateNever]
        [DisplayName("Image")]
        public string ImageUrl { get; set; }
        [Required]
        [DisplayName("Product")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }
    }
}
