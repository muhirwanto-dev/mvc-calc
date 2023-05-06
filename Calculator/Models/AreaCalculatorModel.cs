using System.ComponentModel.DataAnnotations;

namespace Calculator.Models
{
    public class AreaCalculatorModel
    {
        [Display(Name = "Height (mm)")]
        public string Height { get; set; }

        [Display(Name = "Width (mm)")]
        public string Width { get; set; }

        [Display(Name = "Result (mm²)")]
        public string Result { get; set; }
    }
}
