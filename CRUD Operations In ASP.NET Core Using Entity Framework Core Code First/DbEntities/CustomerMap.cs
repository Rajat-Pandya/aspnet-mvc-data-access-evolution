using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD_Operations_In_ASP.NET_Core_Using_Entity_Framework_Core_Code_First.DbEntities
{
    public class CustomerMap
    {
        public CustomerMap(EntityTypeBuilder<Customer> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName).IsRequired();
            entityBuilder.Property(t => t.Email).IsRequired();
            entityBuilder.Property(t => t.MobileNo).IsRequired();
        }
    }
}
