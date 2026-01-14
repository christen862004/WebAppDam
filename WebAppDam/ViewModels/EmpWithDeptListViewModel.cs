using System.ComponentModel.DataAnnotations.Schema;
using WebAppDam.Models;

namespace WebAppDam.ViewModels
{
    public class EmpWithDeptListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int Salary { get; set; }
        public string? Email { get; set; }
        public int DepartmentId { get; set; }

        public List<Department> DeptList { get; set; }
    }
}
