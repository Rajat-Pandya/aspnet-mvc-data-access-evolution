using System.ComponentModel.DataAnnotations;

namespace CRUD_Operations_In_ASP.NET_Core_Using_Entity_Framework_Core_Code_First.DbEntities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string IPAddress { get; set; } = string.Empty;

    }
}
