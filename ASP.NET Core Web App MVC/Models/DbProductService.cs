namespace ASP.NET_Core_Web_App_MVC.Models
{
    public class DbProductService : IProductService
    {
        private readonly AppDbContext _context;

        public DbProductService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
