using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppDam.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        //[Required]
        [MaxLength(50)]
        [MinLength(3,ErrorMessage ="Name Must be More than 3 Char")]
        public string Name { get; set; }

        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image must be jpg or png")]
        public string? ImageUrl { get; set; }

        //[Required]
        //[Range(8000,50000,ErrorMessage ="Salary must between 8000 :50000")]
        [Remote("CheckSalary","Employee",AdditionalFields = "Name",ErrorMessage ="Salary ......")]
        public int Salary { get; set; }

        [Unique]
        public string? Email { get; set; }//entity
        
        [ForeignKey("Department")]
        [Display(Name="Department")]
        public int DepartmentId { get; set; }
        
        public Department? Department { get; set; }//nav allow null remove DIC
    }
}
