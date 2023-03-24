using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorrectCar.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Marca { get; set; }
        [Required]
        [MaxLength(100)]
        public string Model { get; set; }
        [Required]
        public string Descriere { get; set; }
        [Required]
        public double Pret{ get; set; }
        [Required]
        [DisplayName("An de Fabricatie")]
        public string AnFabricatie { get; set; }
        [Required]
        [DisplayName("Capacitate Motor")]
        public double CapacitateMotor { get; set; }
        [Required]
        public int Putere { get; set; }
        [Required]
        [MaxLength(20)]
        public string Combustibil { get; set; }
        [Required]
        public double Rulaj { get; set; }
        [Required]
        [MaxLength(20)]
        public string Culoare { get; set; }
        [Required]
        [DisplayName("Cutia de Viteze")]
        [MaxLength(20)]
        public string CutieViteze { get; set; }
        [Required]
        [MaxLength(20)]
        public string Caroserie { get; set; }
        [MaxLength(200)]
        [ValidateNever]
        [DisplayName("List Image")]
        public string? ListImageUrl { get; set; }


    }
}
