using System.ComponentModel.DataAnnotations;

namespace CRUD_Operations_In_ASP.NET_Core_Using_Entity_Framework_Core_Code_First.DbEntities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
    }
}
