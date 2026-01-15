using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppDam.Models;

namespace WebAppDam.ViewModels
{
    public class EmpWithDeptListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name="Profile Image")]//1)
        [DataType(DataType.Password)]
        public string? ImageUrl { get; set; }//2)

        public int Salary { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public int DepartmentId { get; set; }

        public List<Department> DeptList { get; set; }
    }
}
