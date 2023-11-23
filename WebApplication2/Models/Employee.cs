using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Enter your name")] 
        public string Name {  get; set; }

        [Range(18, 60, ErrorMessage ="Age >= 18 && Age <= 60.")]
        public int Age { get; set; }

        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid")]
        public decimal Salary { get; set; }
        public string Department {  get; set; }

        [RegularExpression(@"^[MF]+$", ErrorMessage = "Select gender.")]
        public Char Sex { get; set; }

    }
}
