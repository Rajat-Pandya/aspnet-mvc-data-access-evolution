using System.ComponentModel.DataAnnotations;

namespace CRUD_using_ASP.NET_Core_Web_App__MVC_.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(100)]
        public string? ProductName { get; set; }

        [Range(0, 99999999.99)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

    }
}
