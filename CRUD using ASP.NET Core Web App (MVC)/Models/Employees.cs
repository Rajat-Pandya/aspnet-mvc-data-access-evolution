using System.ComponentModel.DataAnnotations;

namespace CRUD_using_ASP.NET_Core_Web_App__MVC_.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(100)]
        public string? EmployeeName { get; set; }

        [Required]
        [StringLength(50)]
        public string? Department { get; set; }

        [Range(0, 99999999.99)]
        public decimal Salary { get; set; }
    }
}
