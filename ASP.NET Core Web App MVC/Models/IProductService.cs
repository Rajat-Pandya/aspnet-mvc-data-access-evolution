namespace ASP.NET_Core_Web_App_MVC.Models
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product? GetProductById(int id);

    }
}
