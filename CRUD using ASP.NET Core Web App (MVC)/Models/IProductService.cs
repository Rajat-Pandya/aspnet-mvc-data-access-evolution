namespace CRUD_using_ASP.NET_Core_Web_App__MVC_.Models
{
    public interface IProductService
    {
        IEnumerable<Products> GetAllProducts();
        Products? GetProductById(int id);
        void AddProduct(Products product);
        void UpdateProduct(Products product);
        void DeleteProduct(int id);
    }
}
