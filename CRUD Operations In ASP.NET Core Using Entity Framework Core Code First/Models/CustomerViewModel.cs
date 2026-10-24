using System.ComponentModel.DataAnnotations;

namespace CRUD_Operations_In_ASP.NET_Core_Using_Entity_Framework_Core_Code_First.Models
{
    public class CustomerViewModel
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }
}
