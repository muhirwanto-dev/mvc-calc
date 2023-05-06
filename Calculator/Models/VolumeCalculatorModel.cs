using System.ComponentModel.DataAnnotations;

namespace Calculator.Models
{
    public class VolumeCalculatorModel
    {
        [Display(Name = "Height (mm)")]
        public string Height { get; set; }

        [Display(Name = "Width (mm)")]
        public string Width { get; set; }
        
        [Display(Name = "Wide (mm)")]
        public string Wide { get; set; }

        [Display(Name = "Result (mm³)")]
        public string Result { get; set; }
    }
}
