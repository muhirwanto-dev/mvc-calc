using System.ComponentModel.DataAnnotations;
using Calculator.Services;

namespace Calculator.Models
{
    public class Celsius2FahrenheitModel
    {
        [Display(Name = "Input")]
        public string Input { get; set; }

        [Display(Name = "Output")]
        public string Output { get; set; }

        [Display(Name = "Conversion Mode")]
        public ConverterMode Mode { get; set; }
    }
}
