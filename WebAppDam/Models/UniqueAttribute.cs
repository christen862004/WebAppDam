using System.ComponentModel.DataAnnotations;

namespace WebAppDam.Models
{
    //mvc & web api
    //Server Side C#
    public class UniqueAttribute:ValidationAttribute
    {
        ITIContext context = new ITIContext();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string email = value.ToString();
            Employee? EmpFromReq = validationContext.ObjectInstance as Employee;  //get object from req             

            Employee? EmpFromDB= context.Employees
                .FirstOrDefault(e => e.Email == email && e.DepartmentId == EmpFromReq.DepartmentId);//get obj from db
            if (EmpFromDB == null) {

                //right
                return ValidationResult.Success;
            }
            //invalid
            return new ValidationResult("Email Already Exist :(");
        }
    }
}
